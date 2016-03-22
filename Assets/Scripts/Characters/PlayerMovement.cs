using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float _movementSpeed;

    public void MoveY(float value)
    {
        if (value < 0 /*&& value > -0.5f*/)
        {
            AnimStateHandler.AnimStateGeneral(1);
        }
        /*else if (value < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral();
        }*/
        
        if(value > 0 /*&& value < 0.5f*/)
        {
            AnimStateHandler.AnimStateGeneral(2);
        }
        /*else if (value > 0.5f)
        {
            AnimStateHandler.AnimStateGeneral();
        }*/
        
        transform.Translate(-Vector3.forward * _movementSpeed * Time.deltaTime * value);
    }

    public void MoveX(float value)
    {
        if (value < 0 /*&& value > -0.5f*/)
        {
            AnimStateHandler.AnimStateGeneral(3);
        }/*else if (value < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral();
        }*/
        
        else if(value > 0 /*&& value < 0.5f*/)
        {
            AnimStateHandler.AnimStateGeneral(4);
        }
       
        transform.Translate(-Vector3.left * _movementSpeed * Time.deltaTime * value);
    }
}
