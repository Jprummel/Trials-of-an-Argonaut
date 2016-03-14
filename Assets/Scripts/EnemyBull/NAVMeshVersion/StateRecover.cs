using UnityEngine;
using System.Collections;

public class StateRecover : StateParent {

	[SerializeField] private float _maxSpeed = 10f;

	private Vector3 _startPos;

	private Vector3 _mainTarget;
	private Vector3 _newTarget;


	BullBehaviour bullbehaviour;

	StateCharge stateCharge;

	public override void Enter ()
	{
		bullbehaviour = GetComponent<BullBehaviour> ();
		stateCharge = GetComponent<StateCharge>();

		_startPos = stateCharge.recoverLocation;
		_mainTarget = transform.position;


		bullbehaviour.setSpeed (_maxSpeed);

		_newTarget = _startPos + _mainTarget;

		bullbehaviour.targetPos = _newTarget;
	}

	public override void Leave ()
	{

	} 

	public override void Act ()
	{
		

	}

	public override void Reason ()
	{
		float distanceToTarget = (_newTarget - transform.position).magnitude;
		if (distanceToTarget < 1f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.IdleState);
		}
	}
}
