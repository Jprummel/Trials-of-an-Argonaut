using UnityEngine;
using System.Collections;

public class StateCharge : StateParent {

	[SerializeField] private int _recoverDistance;

	[SerializeField] private GameObject _targetObject;
	private Vector3 _targetPosObject;
	BullBehaviour bullBehaviour;
	StateIdle stateIdle;

	private Vector3 _CurrentTarget;

	private Vector3 _desiredStep;
	private Vector3 _NewTarget;
	private Vector3 _desiredVelocity;

	[SerializeField]private float _chargeSpeed = 50f;

	private bool _isCharging = false;

	public bool isCharging
	{
		get{ return _isCharging; }

	}
	public override void Enter ()
	{
		
		Debug.Log ("Charge");
		bullBehaviour = GetComponent<BullBehaviour> ();
		stateIdle = GetComponent<StateIdle> ();


		_isCharging = true;

	
	}

	public override void Leave()
	{
		_isCharging = false;
	}
	public override void Act ()
	{
		_targetPosObject = _CurrentTarget;
		_targetObject.transform.position = _targetPosObject;

		float distanceToTarget = (_CurrentTarget - transform.position).magnitude;

	
		if (distanceToTarget > 20f) {
			_CurrentTarget = stateIdle.targetPlayer.transform.position;
			bullBehaviour.setSpeed (_chargeSpeed);

			_desiredStep = _CurrentTarget - transform.position;

			_NewTarget = (_desiredStep + transform.position);

			bullBehaviour.targetPos = _NewTarget;
			Debug.Log ("I am doing it!");

		} else {
			Debug.Log ("Damn missed");
		}
		if (distanceToTarget < 2f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.RecoverState);
		}


	}

	public override void Reason ()
	{
		/*float distanceToTarget = (_CurrentTarget - transform.position).magnitude;
		if (distanceToTarget < 2f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.RecoverState);
		}*/
	}



}
