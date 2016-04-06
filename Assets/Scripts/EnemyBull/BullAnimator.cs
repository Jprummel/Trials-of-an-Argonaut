using UnityEngine;
using System.Collections;

public class BullAnimator : MonoBehaviour {

    public static Animator _Animator;
	// Use this for initialization
	void Start () {
        _Animator = GetComponent<Animator>();
	}

    public static void BullAnimation(int whichState)
    {
        _Animator.SetInteger("BullState", whichState);
    }
}
