using UnityEngine;
using System.Collections;

public enum StateID
{
	NullState = 0,
	IdleState = 1,
	ChargeState = 2,
	AttackState = 3,
	FlameState = 4,
	RecoverState = 5

}
public class BullBehaviour : MonoBehaviour {

	private StateMachine _stateMachine;

	private Vector3 _targetPos;
	public Vector3 targetPos
	{
		get{return _targetPos; }
		set{_targetPos = value; }
	}


	private NavMeshAgent _navComponent;


	private float _maxSpeed;
	public float maxSpeed
	{
		get{return _maxSpeed;}
		set{ _maxSpeed = value;}
	}
	// Use this for initialization
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
        _stateMachine.AddState(StateID.FlameState, GetComponent<StateFireBreath>());
	}
	// Update is called once per frame
	void Update () {

		if(_targetPos != null)
		{
			_navComponent.SetDestination(_targetPos);
			//DistanceTo ();

		}
	}

	public void setSpeed(float newSpeed)
	{
	//	_navComponent.speed = newSpeed;
		float speedMultiplyer = 1.0f - 0.9f *  Vector3.Angle (transform.forward, _navComponent.steeringTarget - transform.position) / 180.0f;
		_navComponent.speed = newSpeed * speedMultiplyer;
	}




}
