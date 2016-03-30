using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour 
{
    [Range(1,10)]
    [SerializeField]private float _turnSpeed;

	void FixedUpdate () 
    {
        transform.Rotate(Vector3.up * _turnSpeed * 10f * Time.fixedDeltaTime);
	}
}