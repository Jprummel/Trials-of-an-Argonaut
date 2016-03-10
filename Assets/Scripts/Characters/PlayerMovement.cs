using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float _movementSpeed;
    [SerializeField]private float _jumpHeight;
    private bool _isGrounded;
    private Rigidbody _rigidBody;
    

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void MoveY(float value)
    {
        if (value < 0)
        {
            AnimStateHandler.AnimStateGeneral(1);
        }else if(value > 0)
        {
            AnimStateHandler.AnimStateGeneral(2);
        }
        
        transform.Translate(-Vector3.forward * _movementSpeed * Time.deltaTime * value);
    }

    public void MoveX(float value)
    {
        if (value < 0)
        {
            AnimStateHandler.AnimStateGeneral(3);
        }else if(value > 0)
        {
            AnimStateHandler.AnimStateGeneral(4);
        }
       
        transform.Translate(-Vector3.left * _movementSpeed * Time.deltaTime * value);
    }
}
