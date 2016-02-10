using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    public static Animator _Animator;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public static void AnimState(int whichState)//Sets the animation state
    {
        _Animator.SetInteger("State", whichState);
    }
}
