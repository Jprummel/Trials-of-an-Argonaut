using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    
    public static Animator _Animator;
    private static GameObject _animatedObject;

    void Start()
    {
        _animatedObject = this.gameObject;
        _Animator = GetComponent<Animator>();
    }

    public static void AnimStateOverride(int whichState)//Sets the animation state for the Top Layer (Attack and such)
    {
        _Animator.GetLayerName(0);
        _Animator.SetInteger("OverrideState", whichState);
    }

    public static void AnimStateGeneral(int whichState)//Sets the animation state for general animations (Walking, idles , camera/enviroment)
    {
        if (_animatedObject.tag == Tags.PLAYER)
        {
            _Animator.GetLayerName(1);
            _Animator.SetInteger("GeneralState", whichState);
        }else
        {
            _Animator.GetLayerName(0);
            _Animator.SetInteger("GeneralState", whichState);
        }
    }

    
}
