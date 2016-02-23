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
        /*if (value < 0)
        {
            AnimStateHandler.AnimState();
        }else if(value > 0)
        {
            AnimStateHandler.AnimState();
        }*/
        
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime * value);
    }

    public void MoveX(float value)
    {
       /* if (value < 0)
        {
            AnimStateHandler.AnimState();
        }else if(value > 0)
        {
            AnimStateHandler.AnimState();
        }*/
       
        transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime * value);
    }
}
