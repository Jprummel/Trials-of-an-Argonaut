using UnityEngine;
using System.Collections;

public class StateIdle : StateParent {

	BullBehaviour bullBehaviour;


	[SerializeField] private GameObject _targetPlayer;

	public GameObject targetPlayer{
		get{ return _targetPlayer; }

	}
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _wanderTime;
	private Transform _newTransform;
	private float wanderRadius = 30f;

	public override void Enter ()
	{

		bullBehaviour = GetComponent<BullBehaviour> ();

		bullBehaviour.targetPos = _targetPlayer.transform.position;

		bullBehaviour.setSpeed (_movementSpeed);

		Vector3 newPos = RandomNavSphere (transform.position, wanderRadius, -1);
		bullBehaviour.targetPos = newPos;
	}

	public override void Act ()
	{
		

	}

	public override void Reason ()
	{
		StartCoroutine(wandering (_wanderTime));
	}

	float DistanceTo()
	{
		float distanceToTarget = (this.transform.position - _targetPlayer.transform.position).magnitude;
		return distanceToTarget;
	}

	IEnumerator wandering(float wanderTime)
	{

		yield return new WaitForSeconds (wanderTime);
		DistanceChecker();
	}

	void DistanceChecker()
	{
		if (DistanceTo () >= 30f) 
		{
			GetComponent<StateMachine> ().SetState (StateID.ChargeState);

		}
		else if (DistanceTo () > 10f) 
		{
			
		}

	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
	{
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;
		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		return navHit.position;
	}

	
}
