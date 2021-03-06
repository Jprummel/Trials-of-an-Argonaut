﻿using UnityEngine;
using System.Collections;

public enum StateID
{
	NullState       = 0,
	IdleState       = 1,
	ChargeState     = 2,
	AttackState     = 3,
	FlameState      = 4,
	RecoverState    = 5,
	PrepareState    = 6,
	StaggerState    = 7,
    RunAwayState    = 8
}
public class BullBehaviour : MonoBehaviour {

    [SerializeField]private GameObject      _targetObject;
	                private StateMachine    _stateMachine;
	

	private bool _isCharging = false;

	public bool isCharging
	{
		get{ return _isCharging;  }
		set{ _isCharging = value; }
	}

	private Vector3 _targetPos;
	public Vector3 targetPos
	{
		get{return _targetPos;  } //target of destination
		set{_targetPos = value; }
	}
		
	public bool canICharge = false;

	private NavMeshAgent _navComponent;

    public bool canIFire = true;


	void Start () 
	{
		_navComponent = GetComponent<NavMeshAgent> ();
		_stateMachine = GetComponent<StateMachine> ();

		MakeStates ();

		_stateMachine.SetState (StateID.IdleState);
	}

	void MakeStates()
	{
		_stateMachine.AddState (StateID.IdleState, GetComponent<StateIdle>());
		_stateMachine.AddState (StateID.ChargeState, GetComponent<StateCharge>());
		_stateMachine.AddState (StateID.RecoverState, GetComponent<StateRecover>());
		_stateMachine.AddState (StateID.PrepareState, GetComponent<StatePrepare>());
        _stateMachine.AddState (StateID.FlameState, GetComponent <StateFireBreath>());
		_stateMachine.AddState (StateID.StaggerState, GetComponent<StateStagger>());
        _stateMachine.AddState (StateID.RunAwayState, GetComponent<StateRunAway>());
    }

	void Update ()
	{
		_targetPos.y = 2f;
		RotatingSmooth ();

		if(_targetPos != null)
		{
			_navComponent.SetDestination(_targetPos); 

			_targetObject.transform.position = _targetPos;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (_isCharging && col.gameObject.tag == Tags.PILLAR) 
		{
			GetComponent<StateMachine>().SetState(StateID.StaggerState);
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
		transform.rotation      = Quaternion.RotateTowards (transform.rotation, lookRotation, _navComponent.angularSpeed * Time.deltaTime);
	}

    public void stoppingDistance(float distance)
    {
        _navComponent.stoppingDistance = distance;
    }

    public IEnumerator waitForFire(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canIFire = true;
    }

    public void StartCourotine()
    {
        StartCoroutine(waitForFire(10f));
    }
}
