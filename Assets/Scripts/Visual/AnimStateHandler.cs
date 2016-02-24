using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    public static Animator _Animator;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public static void AnimStateGeneral(int whichState)//Sets the animation state for the General Layer
    {
        _Animator.GetLayerName(0);
        _Animator.SetInteger("State", whichState);
    }

    public static void AnimStateOverride(int whichState)//Sets the animation state for the Override Layer
    {
        _Animator.GetLayerName(1);
        _Animator.SetInteger("State", whichState);
    }
}
