using UnityEngine;
using System.Collections;

public class StateCharge : StateParent {

	//[SerializeField] private int _recoverDistance;

	private Vector3 _targetPosObject;
	BullBehaviour bullBehaviour;

	private Vector3 _CurrentTarget;
	public Vector3 currentTarget
	{
		get{ return _CurrentTarget; }

	}
	[SerializeField] private float _waitTime;
	[SerializeField]private float _chargeSpeed = 200f;

	/*private bool _isCharging = false;
	public bool isCharging
	{
		get{ return _isCharging; }
	}*/
	private Vector3 _recoverLocation;
	public Vector3 recoverLocation
	{
		get{ return _recoverLocation; }

	}

	StatePrepare prepare;

	public override void Enter ()
	{
		
		Debug.Log ("Charge");
		bullBehaviour = GetComponent<BullBehaviour> ();
		prepare = GetComponent<StatePrepare> ();

		_CurrentTarget = prepare.targetPlayer.transform.position;
		bullBehaviour.setSpeed (_chargeSpeed);
		bullBehaviour.acceleration (50);
		bullBehaviour.isCharging = true;
	}

	public override void Leave()
	{
		//bullBehaviour.isCharging = false;
		bullBehaviour.acceleration (30);
	}
	public override void Act ()
	{
		//Running ();
	}

	public override void Reason ()
	{
		if (bullBehaviour.isCharging) 
		{
			Charging ();
		}

	}

	void Charging()
	{
		float distanceToTarget = (_CurrentTarget - transform.position).magnitude; //checked of hij er is. 

		if (distanceToTarget < 2.5f) 
		{

			_recoverLocation = transform.position;
		}
		if (distanceToTarget < 1.5f) {
			GetComponent<StateMachine> ().SetState (StateID.RecoverState);

		} 
	}

}
