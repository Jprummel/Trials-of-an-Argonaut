using UnityEngine;
using System.Collections;

public enum StateID
{
	NullState = 0,
	IdleState = 1,
	ChargeState = 2,
	AttackState = 3,
	FlameState = 4,
	RecoverState = 5,
	PrepareState = 6

}
public class BullBehaviour : MonoBehaviour {

	private StateMachine _stateMachine;
	[SerializeField] private GameObject _targetObject;

	private bool _isCharging = false;
	public bool isCharging
	{
		get{ return _isCharging; }
		set{ _isCharging = value; }
	}

	private Vector3 _targetPos;
	public Vector3 targetPos
	{
		get{return _targetPos; } //target van waar hij nu naar toe moet.
		set{_targetPos = value; }
	}
		
	private NavMeshAgent _navComponent;


	void Start () 
	{
		_navComponent = GetComponent<NavMeshAgent> ();
		_stateMachine = GetComponent<StateMachine> ();

		MakeStates ();

		_stateMachine.SetState (StateID.IdleState);
	}

	void MakeStates()
	{
		_stateMachine.AddState (StateID.IdleState, GetComponent<StateIdle> () );
		_stateMachine.AddState (StateID.ChargeState, GetComponent<StateCharge> ());
		_stateMachine.AddState (StateID.RecoverState, GetComponent<StateRecover> ());
		_stateMachine.AddState (StateID.PrepareState, GetComponent<StatePrepare> ());
	}

	void Update () 
	{
		RotatingSmooth ();

		if(_targetPos != null)
		{
			_navComponent.SetDestination(_targetPos); 

			_targetObject.transform.position = _targetPos;
		}
	}

	public void setSpeed(float newSpeed)
	{

		_navComponent.speed = newSpeed;

	}
	public void acceleration(float newAcc)
	{

		_navComponent.acceleration = newAcc;

	}
	void RotatingSmooth()
	{
		Quaternion lookRotation = Quaternion.LookRotation (_navComponent.desiredVelocity);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, lookRotation, _navComponent.angularSpeed * Time.deltaTime);
	}


}
