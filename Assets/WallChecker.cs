using UnityEngine;
using System.Collections;

public class WallChecker : MonoBehaviour {

	[SerializeField] private int _AggroRange;
	private int _layerMasks;

	BullBehaviour bullBehaviour; 
	// Use this for initialization
	void Start () {
		bullBehaviour = GameObject.FindGameObjectWithTag (Tags.BULL).GetComponent<BullBehaviour> ();
		_layerMasks = LayerMask.GetMask (Tags.WALLS);
	}
	
	// Update is called once per frame
	void Update () {
		Aggro ();
	}
	void Aggro()
	{

		Collider[] col = Physics.OverlapSphere (transform.position, _AggroRange,_layerMasks);

		if (col.Length > 0) {

			bullBehaviour.canICharge = false;
		} else {
			bullBehaviour.canICharge = true;
		}
	}
}
