using UnityEngine;
using System.Collections;

public class ChangeNavObs : MonoBehaviour {

	[SerializeField]private GameObject      _bull;
	        BullBehaviour   _Charge;
	        NavMeshObstacle _MeshObstakels;

	void Start () {
		if (_bull != null) {
			_Charge = _bull.GetComponent<BullBehaviour> ();
		}
			_MeshObstakels  = GetComponent<NavMeshObstacle> ();
	}

	void Update () {
		checkIfCharging ();
	}

	void checkIfCharging()
	{
		if (_Charge.isCharging && _bull != null) {			
			_MeshObstakels.carving = false;

		} else {
			_MeshObstakels.carving = true;
		}
	}
}
