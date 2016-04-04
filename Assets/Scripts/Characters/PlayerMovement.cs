using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
                    
                    private ToggleEnableInput   _inputToggle;
                    private CameraMovement      _cameraMovement;
                    public Vector3              _newForward;
    [SerializeField]private float               _movementSpeed;
    [SerializeField]private float               _turnspeed;
                    public Transform           _playerModel;
                    

    void Start()
    {
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _cameraMovement = GameObject.Find("CameraController").GetComponent<CameraMovement>();
    }

    public void Move(Vector3 vector) 
    {
        if (_inputToggle.CanMove()) { 

            _newForward = Vector3.Normalize(new Vector3(vector.x,0,vector.z) * _turnspeed * Time.deltaTime); //Gets the new forward of the transform from the analog inputs
            
            //Gets value of analog stick for movement speed
            float vectorX = vector.x >= 0 ? vector.x : -vector.x;
            float vectorZ = vector.z >= 0 ? vector.z : -vector.z;
            float maxSpeed = vectorX >= vectorZ ? vectorX : vectorZ;
            
            //Moves character forward
            transform.Translate(_newForward * (_movementSpeed * maxSpeed) * Time.deltaTime);
            
            //Set the foward to the camera forward
            transform.forward = _cameraMovement.cameraForward;

            //Rotates the player towards the angle of the analog stick
            float angle = (Mathf.Atan2(vector.x, vector.z) * 180 / Mathf.PI);
            Quaternion playerRotation = Quaternion.Euler(0f, angle, 0f);
            _playerModel.transform.localRotation = Quaternion.Lerp(_playerModel.transform.localRotation, playerRotation, Time.deltaTime * 7);
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
