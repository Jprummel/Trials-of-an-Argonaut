using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float _movementSpeed;
    [SerializeField]private float _turnspeed;
    private ToggleEnableInput _inputToggle;
    public Vector3 _newForward;

    void Start()
    {
        _inputToggle = GetComponent<ToggleEnableInput>();
    }

    public void Move(Vector3 vector) 
    {
        if (_inputToggle.CanMove()) { 
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime ); // Moves character forward

        _newForward = Vector3.Normalize(new Vector3(vector.x,0,vector.z) * _turnspeed * Time.deltaTime); //Rotates character to face the direcction of the analog stick
        transform.forward = _newForward;
        }
    }

    public void handleAnimations(Vector3 vector)
    {
        if (vector.magnitude > 0 && vector.magnitude < 0.5f || vector.magnitude < 0 && vector.magnitude > 0.5f)
        {
            AnimStateHandler.AnimStateGeneral(1);   //Walk
            AnimStateHandler.AnimStateOverride(1);
        }
        else if (vector.magnitude > 0.5f || vector.magnitude < -0.5f)
        {
            AnimStateHandler.AnimStateGeneral(2);  //Run
            AnimStateHandler.AnimStateOverride(2);
        }
    }
}
