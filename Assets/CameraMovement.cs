using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Transform _playerPos;
    [SerializeField]
    private float _minY;
    [SerializeField]
    private float _maxY;
    private float _cameraY;
    private float _rotationY;
    public Vector3 cameraForward;

    void Start()
    {
        _playerPos = GameObject.Find("CameraTarget").transform;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position  = _playerPos.position;
        cameraForward       = transform.TransformDirection(Vector3.forward);
        cameraForward.y     = 0f;
        cameraForward       = cameraForward.normalized;
    }

    public void RotateX(float rotationSpeed, float value)
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * value);
    }

    public void RotateY(float camSensitivity, float value)
    {
        _rotationY              = Mathf.Clamp(_rotationY, _minY, _maxY);
        transform.eulerAngles   = new Vector3(_rotationY, transform.localEulerAngles.y);
        _rotationY             += Time.deltaTime * camSensitivity * value;

    }
}
