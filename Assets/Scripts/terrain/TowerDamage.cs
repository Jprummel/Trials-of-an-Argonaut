using UnityEngine;
using System.Collections;

public class TowerDamage : MonoBehaviour {

	       Animator _animator;
	[SerializeField] private GameObject _particles;
	private AudioSource _audioCollapse;
    public bool     doDamage = true;

	void Start () {
		_animator = GetComponentInParent<Animator> ();
		_audioCollapse = GetComponent<AudioSource> ();
	}

	public void CheckForPlay()
	{
		if (doDamage) 
        {
			
            _animator.SetBool ("DidHit", true);
			_particles.SetActive (true);
			_audioCollapse.Play ();
			doDamage = false;
		}
	}
}
