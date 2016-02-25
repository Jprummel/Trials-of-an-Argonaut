using UnityEngine;
using System.Collections;

public class StateCharge : StateParent {

	[SerializeField] private int _recoverDistance;

	BullBehaviour bullBehaviour;
	StateIdle stateIdle;

	private Vector3 _CurrentTarget;

	private Vector3 _desiredStep;
	private Vector3 _NewTarget;
	private Vector3 _desiredVelocity;

	[SerializeField]private float _chargeSpeed = 35f;

	private bool _isCharging = false;

	public bool isCharging
	{
		get{ return _isCharging; }

	}
	public override void Enter ()
	{
		bullBehaviour = GetComponent<BullBehaviour> ();
		stateIdle = GetComponent<StateIdle> ();

		bullBehaviour.setSpeed(_chargeSpeed);
		_isCharging = true;

	
	}

	public override void Leave()
	{
		_isCharging = false;
	}
	public override void Act ()
	{
		_CurrentTarget = stateIdle.targetPlayer.transform.position;

		_desiredStep = _CurrentTarget - transform.position;

		_NewTarget =  (_desiredStep + transform.position);

		bullBehaviour.targetPos = _NewTarget;

		Debug.Log (_isCharging);
	}

	public override void Reason ()
	{
		float distanceToTarget = (_CurrentTarget - transform.position).magnitude;
		if (distanceToTarget < 2f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.RecoverState);
		}
	}



}
