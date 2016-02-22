using UnityEngine;
using System.Collections;

public class AttackBehaviour : StateParent {

	[SerializeField] private float _aggroRange = 3f;
	private Vector3 _currentChargeTarget;
	MainBehaviour mainBehaviour;
	public override void Enter ()
	{

		mainBehaviour = GetComponent<MainBehaviour> ();
		Vector3 Target = mainBehaviour.currentTarget;

		_currentChargeTarget = Target;


	}

	public override void Leave ()
	{

	} 

	public override void Act ()
	{
		
		Charging ();
	}

	public override void Reason ()
	{
		float distanceToTarget = (this.transform.position - _currentChargeTarget).magnitude;
		if (distanceToTarget < _aggroRange) 
		{
			GetComponent<StateMachine> ().SetState (StateID.RecoverBull);

		}


	}

	void Charging()
	{

		mainBehaviour.Seek ();


	}


}