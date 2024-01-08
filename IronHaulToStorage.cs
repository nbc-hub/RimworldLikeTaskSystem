public class IronHaulToStorage : GAction
{
    public PigChef pigChef;   
    public override bool PrePerform()
    {   pigChef.Unit_OnStartedMoving();
        return true;
    }

    public override bool Perform(float duration)
    {
        return true;
    }

    public override bool PostPerform()
    {
        pigChef.Unit_OnStoppedMoving();
        return true;
    }

}
