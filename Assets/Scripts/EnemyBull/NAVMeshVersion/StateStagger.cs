using UnityEngine;
using System.Collections;

public class StateStagger : StateParent {
	
    BullBehaviour bullbehaviour;
    BullSound _bullsound;
    
	public override void Enter()
	{
		bullbehaviour = GetComponent<BullBehaviour> ();
        _bullsound = GetComponent<BullSound>();
		bullbehaviour.isCharging = false;
		bullbehaviour.acceleration (1000f);
		bullbehaviour.setSpeed (0f);
		BullAnimator.BullAnimation(5);
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
		BullAnimator.BullAnimation(6);
		yield return new WaitForSeconds (waitTime);
		GetComponent<StateMachine> ().SetState (StateID.IdleState);
        _bullsound.AngrySound();
	}
}


