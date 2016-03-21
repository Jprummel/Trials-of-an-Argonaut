using UnityEngine;
using System.Collections;

public class ChangeNavObs : MonoBehaviour {

	private GameObject _bull;
	BullBehaviour _Charge;
	NavMeshObstacle _MeshObstakels;

	void Start () {
		_bull = GameObject.FindGameObjectWithTag ("Bull");
		_Charge = _bull.GetComponent<BullBehaviour> ();
		_MeshObstakels = GetComponent<NavMeshObstacle> ();

	}

	void Update () {
		checkIfCharging ();
	}
	void checkIfCharging()
	{
		if (_Charge.isCharging) {			
			_MeshObstakels.carving = false;

		} else {
			_MeshObstakels.carving = true;

		}
	}
}
