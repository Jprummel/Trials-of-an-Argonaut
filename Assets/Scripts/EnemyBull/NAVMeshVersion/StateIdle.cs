using UnityEngine;
using System.Collections;

public class StateIdle : StateParent {
    
    [SerializeField]private float           _movementSpeed;    	
	                private Transform       _newTransform;
	                private NavMeshPath     _path;
	                private NavMeshAgent    _agent;
	                private float           _wanderRadius = 20f;
                    private Vector3         _newPos;
                            BullBehaviour   bullBehaviour;
	
    public override void Enter ()
	{
		bullBehaviour = GetComponent<BullBehaviour> ();
		_agent = GetComponent<NavMeshAgent> ();

		bullBehaviour.isCharging = false;
		bullBehaviour.acceleration(10);

		bullBehaviour.setSpeed (_movementSpeed);

		_newPos = RandomNavSphere (transform.position, _wanderRadius, -1);
		bullBehaviour.targetPos = _newPos;

		_path = new NavMeshPath ();
	}

	public override void Act ()
	{
		_agent.CalculatePath (_newPos, _path);

		if (_path.status == NavMeshPathStatus.PathPartial) 
		{
			GetComponent<StateMachine> ().SetState (StateID.IdleState);
		}
	}

	public override void Reason ()
	{
		float distanceTo = (this.transform.position - _newPos).magnitude;

		if (distanceTo < 1f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.PrepareState);
		}
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) //Looks for random location within range.
	{
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;
		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		return navHit.position;
	}

}
