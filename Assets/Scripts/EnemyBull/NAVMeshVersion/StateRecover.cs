using UnityEngine;
using System.Collections;

public class StateRecover : StateParent {

	[SerializeField]private float           _maxSpeed = 18f;
	[SerializeField]private GameObject      _rotatePos1;
	[SerializeField]private GameObject      _rotatePos2;
                    private Vector3         _startPos;
	                private Vector3         _mainTarget;
	                private Vector3         _newTarget;
	                private bool            _Zside;
	                        BullBehaviour   bullbehaviour;
	                        StateCharge     stateCharge;

	public override void Enter ()
	{
		bullbehaviour   = GetComponent<BullBehaviour> ();
		stateCharge     = GetComponent<StateCharge>();

		_startPos = stateCharge.recoverLocation;

		bullbehaviour.setSpeed (_maxSpeed);

		if (transform.position.z > 0) {
			_Zside = true;
		} else {
			_Zside = false;
		}
	}

	public override void Leave ()
	{
	} 

	public override void Act ()
	{
		AnimStateHandler.AnimStateGeneral (5);
		if (_Zside) {
			_newTarget = _rotatePos2.transform.position;
		} else {
			_newTarget = _rotatePos1.transform.position;
		}

		_newTarget.y = 2;
		bullbehaviour.targetPos = _newTarget;
	}

	public override void Reason ()
	{
		float distanceToTarget = (_startPos	 - transform.position).magnitude;
		if (distanceToTarget > 13f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.IdleState);
		}
	}
}
