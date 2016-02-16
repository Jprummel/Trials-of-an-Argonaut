using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {

    [SerializeField]private float _rotationSpeed;
    private Transform _camera;
    [SerializeField]private float _minX;
    [SerializeField]private float _maxX;
    [SerializeField]private float _camSensitivityX;
    private float _cameraY;
    private float _rotationX;

    void Start()
    {
        _camera = transform.GetChild(0);
        _cameraY = _camera.transform.rotation.y;
    }

    void Update()
    {
        
    }

    public void RotateY(float value)
    {
        
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime * value);
    }

    public void RotateX(float value)
    {
        _rotationX = Mathf.Clamp(_rotationX, _minX, _maxX);
        _camera.transform.eulerAngles = new Vector3(_rotationX, 0);
        _rotationX -= Time.deltaTime * _camSensitivityX * value;
    }
}
