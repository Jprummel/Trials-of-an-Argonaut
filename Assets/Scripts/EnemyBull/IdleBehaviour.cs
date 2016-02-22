using UnityEngine;
using System.Collections;

public class IdleBehaviour : StateParent {
	
	[SerializeField] private GameObject _target;
	[SerializeField] private float _MaxSpeed = 30f;
	[SerializeField] private float waitTimer = 1f;
	MainBehaviour mainBehaviour;

	public override void Enter ()
	{
		
		mainBehaviour = GetComponent<MainBehaviour> ();
		mainBehaviour.maxSpeed = _MaxSpeed;

		StartCoroutine(Waiting(waitTimer));

	}

	public override void Leave ()
	{
	} 

	public override void Act ()
	{
		mainBehaviour.setTarget (_target.transform.position);
		mainBehaviour.Rotating ();



	}

	public override void Reason ()
	{


	}

	IEnumerator Waiting(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		GetComponent<StateMachine> ().SetState (StateID.AttackBull);
	}
}
