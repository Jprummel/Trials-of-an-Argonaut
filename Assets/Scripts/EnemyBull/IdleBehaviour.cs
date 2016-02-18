using UnityEngine;
using System.Collections;

public class IdleBehaviour : StateParent {
	
	[SerializeField] private GameObject _target;

	MainBehaviour mainBehaviour;

	public override void Enter ()
	{
		mainBehaviour = GetComponent<MainBehaviour> ();
		mainBehaviour.setTarget (_target.transform.position);

		StartCoroutine(Waiting(2.0f));

	}

	public override void Leave ()
	{
		Debug.Log ("I leave");
	} 

	public override void Act ()
	{
		mainBehaviour.Rotating ();
		Debug.Log ("I rotate");


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
