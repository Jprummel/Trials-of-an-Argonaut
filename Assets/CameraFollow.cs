using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform _target;
    private Vector3 _offset;
    private float _damping = 10f;

    void Awake()
    {
        _offset = _target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        if (_target)
        {
            //Move to Target
            float desiredAngle = _target.transform.eulerAngles.y;
            Quaternion playerRotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = _target.transform.position - (playerRotation * _offset);
            
            //Look at and dampen the rotation
            Quaternion cameraRotation = Quaternion.LookRotation(_target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime * _damping);
        }
    }
}
