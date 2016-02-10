using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    Animator _Animator;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public void AnimState(int whichState)//Sets the animation state
    {
        _Animator.SetInteger("State", whichState);
    }
}
