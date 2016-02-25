using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    private Transform _camera;
    [SerializeField]private float _minX;
    [SerializeField]private float _maxX;
    private float _cameraY;
    private float _rotationX;

    void Start()
    {
        _camera = transform.GetChild(0);
    }

    public void RotateY(float rotationSpeed, float value)
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * value);
    }

    public void RotateX(float camSensitivity, float value)
    {
        _rotationX = Mathf.Clamp(_rotationX, _minX, _maxX);
        _camera.transform.eulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y);
        _rotationX += Time.deltaTime * camSensitivity * value;
    }

    public void CenterCamera()
    {
        _camera.transform.eulerAngles = new Vector3(0, transform.localEulerAngles.y);
        _rotationX = 0;
    }
}
