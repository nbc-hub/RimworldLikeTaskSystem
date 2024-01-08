using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
public class BuildBarrack : GAction
{

    public PigChef pigChef;
    BuildingConstruction buildingConstruction;
    public override bool PrePerform()
    {
        // Get a free iron

        target = GWorld.Instance.GetQueue("buildings").RemoveResource();
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
        StopAllCoroutines();
        buildingConstruction = target.GetComponent<BuildingConstruction>();
        StartCoroutine(BuildIt(duration));
        return true;
    }

    public override bool PostPerform()
    {

        // Add a new state IronGathering
        GWorld.Instance.GetWorld().ModifyState("BuildConstructed", 1);
        // Remove the iron from the list
        inventory.RemoveItem(target);
        pigChef.Unit_OnGoingToStorage();
        return true;
    }

    IEnumerator BuildIt(float time)
    {
        buildingConstruction.AddProgress(35);
        yield return new WaitForSeconds(time/3);
        buildingConstruction.AddProgress(35);
        yield return new WaitForSeconds(time/3);
        buildingConstruction.AddProgress(35);


        
    }

}
