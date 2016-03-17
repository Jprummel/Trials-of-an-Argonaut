using UnityEngine;
using System.Collections;

public class StateIdle : StateParent {

	BullBehaviour bullBehaviour;


	[SerializeField] private float _movementSpeed;

	private Transform _newTransform;

	private NavMeshPath _path;
	private NavMeshAgent _agent;

	private float wanderRadius = 20f;

	private Vector3 _newPos; 
	public override void Enter ()
	{

		bullBehaviour = GetComponent<BullBehaviour> ();
		_agent = GetComponent<NavMeshAgent> ();

		bullBehaviour.isCharging = false;
		bullBehaviour.acceleration(8);

		bullBehaviour.setSpeed (_movementSpeed);

		_newPos = RandomNavSphere (transform.position, wanderRadius, -1);
		bullBehaviour.targetPos = _newPos;


		_path = new NavMeshPath ();

	}

	public override void Act ()
	{
		_agent.CalculatePath (_newPos, _path);
		Debug.Log (_path.status);
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
	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) //zoekt een random lokatie binnen de range.
	{
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;
		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		return navHit.position;
	}

}
