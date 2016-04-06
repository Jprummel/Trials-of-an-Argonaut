using UnityEngine;
using System.Collections;

public class StatePrepare : StateParent {

	[SerializeField]private GameObject      _targetPlayer;
                    private Vector3         _startZone;               
                            BullBehaviour   bullBehaviour;

    public GameObject targetPlayer
	{
		get{ return _targetPlayer; }
	}	

	public override void Enter ()
	{
		_startZone = transform.position;

		bullBehaviour = GetComponent<BullBehaviour> ();
	}

	public override void Leave()
	{
	}

	public override void Act ()
	{
		AnimStateHandler.AnimStateGeneral (1);
        if (_targetPlayer != null)
        {
            bullBehaviour.targetPos = _targetPlayer.transform.position;
        }
	}

	public override void Reason ()
	{
		float distanceToBeginPoint = (this.transform.position - _startZone).magnitude;
		if (distanceToBeginPoint >= 4f) 
		{
			DistanceChecker ();
		}
	}

	float DistanceTo()
	{
		float distanceToTarget = (this.transform.position - _targetPlayer.transform.position).magnitude;
		return distanceToTarget; //Checks distance to target.
	}
		
	void DistanceChecker() //Checks which state he should enter
	{
		if (DistanceTo () >= 30f) 
		{
			if (bullBehaviour.canICharge) {
				GetComponent<StateMachine> ().SetState (StateID.ChargeState);

			} else {
				GetComponent<StateMachine> ().SetState (StateID.IdleState);
			}
		}
		else if (DistanceTo () < 16f) 
		{
            Debug.Log(bullBehaviour.canIFire);
            bullBehaviour.setSpeed(0);
            if (bullBehaviour.canIFire)
            {
                bullBehaviour.canIFire = false;
                GetComponent<StateMachine>().SetState(StateID.FlameState);

            } else {
                GetComponent<StateMachine>().SetState(StateID.RunAwayState);
            }
        }
	}
}