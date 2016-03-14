using UnityEngine;
using System.Collections;

public class StateIdle : StateParent {

	BullBehaviour bullBehaviour;


	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _wanderTime;
	private Transform _newTransform;
	private float wanderRadius = 30f;

	private Vector3 _newPos; 
	public override void Enter ()
	{

		bullBehaviour = GetComponent<BullBehaviour> ();
		bullBehaviour.acceleration(8);
		bullBehaviour.setSpeed (_movementSpeed);

		_newPos = RandomNavSphere (transform.position, wanderRadius, -1);
		bullBehaviour.targetPos = _newPos;

	}

	public override void Act ()
	{

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
