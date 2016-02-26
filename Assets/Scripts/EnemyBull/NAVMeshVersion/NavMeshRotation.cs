/*using UnityEngine;
using System.Collections;

public class NavMeshRotation : MonoBehaviour {

	private NavMeshAgent _agent;
	// Use this for initialization
	void Start () {
		_agent = gameObject.GetComponent("NavMeshAgent") as NavMeshAgent;
	}
	
	// Update is called once per frame
	void Update () {
		changeSpeed();
	}

	void changeSpeed()
	{
		float speedMultiplyer = 1.0f = 0.9f * Vector3.Angle (transform.forward, _agent.steeringTarget - transform.position) / 180.0f;
		_agent.speed = moveSpeed * speedMultiplyer;
	}
}
*/