using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    [SerializeField]private Transform   _playerPos;
    [SerializeField]private float       _minY;
    [SerializeField]private float       _maxY;
    [SerializeField]private float       _damping;
                    private float       _cameraY;
                    private float       _rotationY;
                    private float       _rotationX;
                    public Vector3      cameraForward;

    void Update()
    {
        UpdateRotation();
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        //Move the camera smoothly to the position of the player and gives the normalized camera forward as a Vector3
        if(_playerPos.position != null)
        {
            transform.position  = Vector3.Lerp(transform.position, _playerPos.position, Time.deltaTime * _damping);
        }

        cameraForward       = transform.TransformDirection(Vector3.forward);
        cameraForward.y     = 0f;
        cameraForward       = cameraForward.normalized;
    }

    public void RotateX(float rotationSpeed, float value)
    {
        //Rotates the camera horizontally
        _rotationX += Time.deltaTime * rotationSpeed * value;
    }

    public void RotateY(float camSensitivity, float value)
    {
        //Rotates and clamps the camera vertically
        _rotationY += Time.deltaTime * camSensitivity * value;
        _rotationY  = Mathf.Clamp(_rotationY, _minY, _maxY);
    }

    private void UpdateRotation()
    {
        //Updates the camera rotations
        Vector3 rotation = new Vector3(_rotationY, _rotationX);
        transform.eulerAngles = rotation;
    }
}
