using UnityEngine;
using System.Collections;

public class StateRunAway : StateParent
{
                            BullBehaviour   bullBehaviour;
    [SerializeField]private GameObject      _way1;
    [SerializeField]private GameObject      _way2;
    [SerializeField]private GameObject      _Player;
                    private float           _PlayerX;

    public override void Enter()
    {
        bullBehaviour   = GetComponent<BullBehaviour>();
        _PlayerX        = _Player.transform.position.x;
        bullBehaviour.setSpeed(20f);
    }

    public override void Leave()
    {
    }

    public override void Act()
    {
        if (_PlayerX > 0)
        {
            //move to way 2
            bullBehaviour.targetPos = _way2.transform.position;
        }
        else
        {
            //move to way 1
            bullBehaviour.targetPos = _way1.transform.position;
        }
    }

    public override void Reason()
    {
        float distanceTo = (this.transform.position - bullBehaviour.targetPos).magnitude;
		Debug.Log (distanceTo);
        if (distanceTo <6f)
        {
            GetComponent<StateMachine>().SetState(StateID.IdleState);
        }
    }
}
