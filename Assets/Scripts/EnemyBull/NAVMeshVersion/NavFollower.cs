using UnityEngine;
using System.Collections;

public class NavFollower : MonoBehaviour {

	[SerializeField]private Transform       _targetPos;
	                private NavMeshAgent    _navComponent;

	void Start () 
    {
		_navComponent = this.transform.GetComponent<NavMeshAgent> ();
	}

	void Update () 
    {
		if(_targetPos)
		{
		_navComponent.SetDestination(_targetPos.position);
		}
	}
}
