using UnityEngine;
using System.Collections;

public class TowerDamage : MonoBehaviour {

	Animator _animator;
	public bool doDamage = true;
	// Use this for initialization
	void Start () {
		_animator = GetComponentInParent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckForPlay()
	{
		if (doDamage) {

			_animator.SetBool ("DidHit", true);
			doDamage = false;

		}
	}
}
