using UnityEngine;
using System.Collections;

public class TowerDamage : MonoBehaviour {

	       Animator _animator;
	public bool     doDamage = true;

	void Start () {
		_animator = GetComponentInParent<Animator> ();
	}

	public void CheckForPlay()
	{
		if (doDamage) 
        {
			_animator.SetBool ("DidHit", true);
			doDamage = false;
		}
	}
}
