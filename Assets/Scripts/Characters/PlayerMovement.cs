using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
                    
                    private ToggleEnableInput   _inputToggle;
                    private CameraMovement      _cameraMovement;
                    public Vector3              _newForward;
    [SerializeField]private float               _movementSpeed;
    [SerializeField]private float               _turnspeed;
                    

    void Start()
    {
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _cameraMovement = GameObject.Find("CameraController").GetComponent<CameraMovement>();
    }

    public void Move(Vector3 vector) 
    {
        if (_inputToggle.CanMove()) { 

            _newForward = Vector3.Normalize(new Vector3(vector.x,0,vector.z) * _turnspeed * Time.deltaTime); //Rotates character to face the direcction of the analog stick

            transform.Translate(_newForward * _movementSpeed * Time.deltaTime); // Moves character forward

            transform.forward = _cameraMovement.cameraForward;
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
