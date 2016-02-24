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
            AnimStateHandler.AnimStateBottom(1);
        }else if(value > 0)
        {
            AnimStateHandler.AnimStateBottom(2);
        }
        
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime * value);
    }

    public void MoveX(float value)
    {
       /* if (value < 0)
        {
            AnimStateHandler.AnimStateBottom();
        }else if(value > 0)
        {
            AnimStateHandler.AnimStateBottom();
        }*/
       
        transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime * value);
    }

    public void Jump()
    {
        AnimStateHandler.AnimStateBottom(5);
        Debug.Log("Jump");
        if (_isGrounded)
        {
            _rigidBody.velocity = new Vector3(0, _jumpHeight, 0);
            _isGrounded = false;
        }
    }

    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Tags.GROUND)
        {
            _isGrounded = true;
        }
    }*/

    public bool IsGrounded()
    {
        return _isGrounded = true;
    }
}
