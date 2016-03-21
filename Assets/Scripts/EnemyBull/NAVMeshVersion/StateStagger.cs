using UnityEngine;
using System.Collections;

public class StateStagger : StateParent {
	BullBehaviour bullbehaviour;


	public override void Enter()
	{
		bullbehaviour = GetComponent<BullBehaviour> ();
		bullbehaviour.isCharging = false;
		bullbehaviour.acceleration (1000f);
		bullbehaviour.setSpeed (0f);
		StartCoroutine (WaitAndRecover (4.0f));
	}
	public override void Leave()
	{
		
	}


	public override void Act()
	{

	}

	public override void Reason()
	{
		
	}

	IEnumerator WaitAndRecover(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		print ("I wanted");
		GetComponent<StateMachine> ().SetState (StateID.IdleState);

	}
}


