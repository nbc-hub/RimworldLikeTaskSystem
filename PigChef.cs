using UnityEngine;

public class PigChef : GAgent
{

    [SerializeField] private Animator animator;
    [SerializeField] private AnimEvents animEvents;
    [SerializeField] private ParticleSystem slashEffect;
    [SerializeField] private ParticleSystem reverseSlashEffect;
    [SerializeField] private ParticleSystem walkingParticle;
    SubGoal s1;
    SubGoal s2;
    SubGoal s3;
    SubGoal s4;
    new void Start()
    {


        base.Start();

        s1 = new SubGoal("HauledIron", 1, false);
        goals.Add(s1, 1);

        s2 = new SubGoal("HauledStone", 1, false);
        goals.Add(s2, 1);

        s3 = new SubGoal("HauledWood", 1, false);
        goals.Add(s3, 1);

        s4 = new SubGoal("Constructed", 1, true);
        goals.Add(s4, 1);

    }

    public void ChangePriorityIron(int priorityInt)
    {

        if (goals.ContainsKey(s1))
        {
            goals[s1] = priorityInt;
        }
    }

    public void ChangePriorityStone(int priorityInt)
    {
        if (goals.ContainsKey(s2))
        {
            goals[s2] = priorityInt;
        }
    }

    public void ChangePriorityWood(int priorityInt)
    {

        if (goals.ContainsKey(s3))
        {
            goals[s3] = priorityInt;
        }
    }

    public void ChangePriorityBuild(int priorityInt)
    {

        if (goals.ContainsKey(s4))
        {
            goals[s4] = priorityInt;
        }
    }


    public void Unit_OnStateBackToNormalMovement()
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void Unit_OnGoingToStorage()
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void Unit_OnStartGathering()
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", true);
        }
    }

    public void Unit_OnStoppedMoving()
    {
        walkingParticle.Stop();
        if (animator != null)
        {
            animator.SetBool("IsWalking", false);
        }
    }

    public void Unit_OnStartedMoving()
    {
        walkingParticle.Play();
        if (animator != null)
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", true);
            animator.SetFloat("MovingSpeed", 1f);
        }
    }
}