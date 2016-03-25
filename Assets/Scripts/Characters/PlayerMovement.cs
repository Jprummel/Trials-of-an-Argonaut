using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float _movementSpeed;
    public float _turnspeed;

    public void Move(Vector3 vector) 
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime ); // Moves character forward

        transform.forward = Vector3.Normalize(new Vector3(vector.x,0,vector.z) * _turnspeed * Time.deltaTime); //Rotates character to face the direcction of the analog stick
    }

    public void handleAnimations(Vector3 vector)
    {
        if (vector.magnitude > 0 && vector.magnitude < 0.5f || vector.magnitude < 0 && vector.magnitude > 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(1);   //Walk
        }
        else if (vector.magnitude > 0.5f || vector.magnitude < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(10);  //Run
        }
    }
}
