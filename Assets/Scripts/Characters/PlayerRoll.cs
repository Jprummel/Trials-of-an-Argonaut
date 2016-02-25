using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour {

    private Rigidbody _rigidBody;
    private float _rollCooldown = 1.3f;
    private bool _CanUsesDodge = true;
    [SerializeField] private int _rollSpeed = 110;
    


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float leftX = Input.GetAxis(InputAxes.LEFTX);
        float leftY = Input.GetAxis(InputAxes.LEFTY);

        if (leftX != 0 && (Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            if (leftX < 0 && _CanUsesDodge == true)
            {
            //roll left
                StartCoroutine(RollLeft());
            }
            else if (leftX > 0 && _CanUsesDodge == true)
            { 
            //roll right
                StartCoroutine(RollRight());
            }
        }

        if (leftY != 0 && (Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            if (leftY < 0 && _CanUsesDodge == true)
            {
                //roll front
                StartCoroutine(RollUp());
            }
            else if (leftY > 0 && _CanUsesDodge == true)
            {
                //roll back
                StartCoroutine(RollDown());
            }
        }

    }

    IEnumerator RollLeft()
    {
        _CanUsesDodge = false;
        _rigidBody.AddForce(-transform.right * _rollSpeed * 4);
        yield return new WaitForSeconds(_rollCooldown);
        _CanUsesDodge = true;
       
    }
    IEnumerator RollRight()
    {
        _CanUsesDodge = false;
        _rigidBody.AddForce(transform.right * _rollSpeed * 4);
        yield return new WaitForSeconds(_rollCooldown);
        _CanUsesDodge = true;
    }
    IEnumerator RollUp()
    {
        _CanUsesDodge = false;
        _rigidBody.AddForce(transform.forward * _rollSpeed * 4);
        yield return new WaitForSeconds(_rollCooldown);
        _CanUsesDodge = true;
    }
    IEnumerator RollDown()
    {
        _CanUsesDodge = false;
        _rigidBody.AddForce(-transform.forward * _rollSpeed * 4);
        yield return new WaitForSeconds(_rollCooldown);
        _CanUsesDodge = true;
    }
}
