using UnityEngine;
using System.Collections;

public class StatePrepare : StateParent {

	[SerializeField] private GameObject _targetPlayer;
	public GameObject targetPlayer
	{
		get{ return _targetPlayer; }
	}
	private Vector3 _startZone;

	BullBehaviour bullBehaviour;

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
        if (_targetPlayer != null)
        {
            bullBehaviour.targetPos = _targetPlayer.transform.position;
        }
	}

	public override void Reason ()
	{
		float distanceToBeginPoint = (this.transform.position - _startZone).magnitude;
		if (distanceToBeginPoint >= 6f) 
		{
			DistanceChecker ();
		}
	}

	float DistanceTo()
	{
		float distanceToTarget = (this.transform.position - _targetPlayer.transform.position).magnitude;
		return distanceToTarget; //checked de distanced naar de target.
	}
		
	void DistanceChecker() //checked welke state hij moet gaan
	{
		if (DistanceTo () >= 30f) 
		{
			if (bullBehaviour.canICharge) {
				GetComponent<StateMachine> ().SetState (StateID.ChargeState);

			} else {
				GetComponent<StateMachine> ().SetState (StateID.IdleState);
			}
		}
		else if (DistanceTo () < 10f) 
		{

            GetComponent<StateMachine>().SetState(StateID.FlameState);
		}

	}

}