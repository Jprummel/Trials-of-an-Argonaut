using UnityEngine;
using System.Collections;

public class StateRunAway : StateParent
{
    BullBehaviour bullBehaviour;
    [SerializeField]
    private GameObject way1;
    [SerializeField]
    private GameObject way2;
    [SerializeField]
    private GameObject Player;
    private float PlayerX;

    public override void Enter()
    {
        Debug.Log("Je moeder");
        bullBehaviour = GetComponent<BullBehaviour>();
        PlayerX = Player.transform.position.x;
        bullBehaviour.setSpeed(20f);
    }

    public override void Leave()
    {


    }
    public override void Act()
    {
        if (PlayerX > 0)
        {
            //move to way 2
            bullBehaviour.targetPos = way2.transform.position;
        }
        else
        {
            //move to way 1
            bullBehaviour.targetPos = way1.transform.position;
        }
    }

    public override void Reason()
    {
        float distanceTo = (this.transform.position - bullBehaviour.targetPos).magnitude;

        if (distanceTo < 1f)
        {
            GetComponent<StateMachine>().SetState(StateID.IdleState);
        }
    }
}
