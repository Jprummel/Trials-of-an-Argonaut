using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    public static Animator _Animator;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public static void AnimStateBottom(int whichState)//Sets the animation state for the general layer (lower body movements)
    {
        _Animator.GetLayerName(1);
        _Animator.SetInteger("State", whichState);
    }

    public static void AnimStateTop(int whichState)//Sets the animation state for combat related animations (upper body movements)
    {
        _Animator.GetLayerName(0);
        _Animator.SetInteger("State", whichState);
    }
}
