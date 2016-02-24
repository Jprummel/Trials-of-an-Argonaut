using UnityEngine;
using System.Collections;

public class StateRecover : StateParent {

	[SerializeField] private float _maxSpeed = 20f;
	[SerializeField] private float _waitForRecover = 1f;

	private Vector3 _startPos;
	private Vector3 _currentPosition;

	private Vector3 _mainTarget;
	private Vector3 _newTarget;


	BullBehaviour bullbehaviour;
	StateIdle stateIdle; 

	public override void Enter ()
	{
		_startPos = transform.position;

		bullbehaviour = GetComponent<BullBehaviour> ();
		stateIdle = GetComponent<StateIdle> ();

		bullbehaviour.setSpeed (_maxSpeed);

		_mainTarget = stateIdle.targetPlayer.transform.position;
		_newTarget = _mainTarget + _startPos;

		bullbehaviour.targetPos = _newTarget;

		StartCoroutine (Waiting (_waitForRecover));
	}

	public override void Leave ()
	{

	} 

	public override void Act ()
	{
		

	}

	public override void Reason ()
	{

	}

	IEnumerator Waiting(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		GetComponent<StateMachine> ().SetState (StateID.IdleState);

	}
}
