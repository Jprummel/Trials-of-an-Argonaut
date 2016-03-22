using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float _movementSpeed;

    public void MoveY(float value)
    {
        if (value < 0 && value > -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(1);
        }
        else if (value < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(10);
        }
        
        if(value > 0  && value < 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(2);
        }
        else if (value > 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(11);
        }
        
        transform.Translate(-Vector3.forward * _movementSpeed * Time.deltaTime * value);
    }

    public void MoveX(float value)
    {
        if (value < 0 && value > -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(3);
        }else if (value < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(12);
        }
        
        if(value > 0 && value < 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(4);
        }
        else if (value > 0.5)
        {
            AnimStateHandler.AnimStateGeneral(13);
        }
       
        transform.Translate(-Vector3.left * _movementSpeed * Time.deltaTime * value);
    }
}
