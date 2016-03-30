using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    
    public static Animator _Animator;

    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public static void AnimStateGeneral(int whichState)//Sets the animation state for the Bottom Layer
    {
        _Animator.GetLayerName(0);
        _Animator.SetInteger("GeneralState", whichState);
    }

    public static void AnimStateOverride(int whichState)//Sets the animation state for the Top Layer
    {
        _Animator.GetLayerName(1);
        _Animator.SetInteger("OverrideState", whichState);
    }
}
