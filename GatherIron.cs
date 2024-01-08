using System;
using System.Diagnostics;
public class GatherIron : GAction {

    public PigChef pigChef;    
    public override bool PrePerform() {
        // Get a free iron
        
        target = GWorld.Instance.GetQueue("irons").RemoveResource();
        inventory.AddItem(target);
        // Check that we did indeed get a iron
        if (target == null)
            // No cubicle so return false
            return false;
        // All good
        pigChef.Unit_OnStartedMoving();
        return true;
    }

    public override bool Perform(float duration)
    {
        pigChef.Unit_OnStoppedMoving();
        pigChef.Unit_OnStartGathering();
        return true;
    }
    
    public override bool PostPerform() {

        // Add a new state IronGathering
        GWorld.Instance.GetWorld().ModifyState("IronGathering", 1);
        // Give back the iron
        GWorld.Instance.GetQueue("irons").AddResource(target);
        // Remove the iron from the list
        inventory.RemoveItem(target);
        // Give the iron back to the world
        GWorld.Instance.GetWorld().ModifyState("FreeIron", 1);
        pigChef.Unit_OnGoingToStorage();
        return true;
    }

}
