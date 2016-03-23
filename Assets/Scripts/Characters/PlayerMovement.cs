using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float _movementSpeed;
    
    public void MoveY(float value)
    {
        if (value < 0 && value > -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(1);   //Walk Forward
        }
        else if (value < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(10);  //Run Forward
        }
        
        if(value > 0  && value < 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(2);   //Walk Backward
        }
        else if (value > 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(11);  //Run Backward
        }
        
        transform.Translate(-Vector3.forward * _movementSpeed * Time.deltaTime * value);
    }

    public void MoveX(float value)
    {
        if (value < 0 && value > -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(3);   //Walk Left
        }else if (value < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(12);  //Run Left
        }
        
        if(value > 0 && value < 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(4);   //Walk Right
        }
        else if (value > 0.5)
        {
            AnimStateHandler.AnimStateGeneral(13);  //Run Right
        }
       
        transform.Translate(-Vector3.left * _movementSpeed * Time.deltaTime * value);
    }
}
