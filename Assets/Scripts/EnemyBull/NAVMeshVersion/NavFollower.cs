using UnityEngine;
using System.Collections;

public class NavFollower : MonoBehaviour {

	[SerializeField]private Transform _targetPos;
	private NavMeshAgent _navComponent;


	// Use this for initialization
	void Start () {

		_navComponent = this.transform.GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {

		if(_targetPos)
		{
		_navComponent.SetDestination(_targetPos.position);
		}


	}
}
