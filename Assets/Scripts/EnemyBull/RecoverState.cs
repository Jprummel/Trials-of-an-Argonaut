using UnityEngine;
using System.Collections;

public class RecoverState : StateParent {

	[SerializeField] private float _maxSpeed = 20f;
	[SerializeField] private float _waitForRecover = 1f;
	MainBehaviour mainBehaviour;

	private Vector3 _currentPosition;
	private Vector3 _beginPos;
	private Vector3 _newTarget;

	private Vector3 _mainTarget;

	public override void Enter ()
	{
		_beginPos = transform.position;

		mainBehaviour = GetComponent<MainBehaviour> ();


		StartCoroutine(Waiting(_waitForRecover));
	}

	public override void Leave ()
	{

	} 

	public override void Act ()
	{
		_mainTarget = mainBehaviour.currentTarget;
		_newTarget = _mainTarget + mainBehaviour.currentVelocity;
	
		mainBehaviour.setTarget (_newTarget);
		mainBehaviour.maxSpeed = _maxSpeed;
		mainBehaviour.Seek ();
	}

	public override void Reason ()
	{

	}
	IEnumerator Waiting(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		GetComponent<StateMachine> ().SetState (StateID.IdleBull);
	}

}