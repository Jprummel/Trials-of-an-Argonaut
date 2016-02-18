using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

    [SerializeField]private float _rotationSpeed;

    public void CamRotation(float value)
    {
        transform.Rotate(-Vector3.left * _rotationSpeed * Time.deltaTime * value);
    }
}
