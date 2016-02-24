using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour {

    private Rigidbody _rigidBody;
    private float _rollCooldown = 1.3f;
    private bool _CanUsesDodge = true;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
  
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton5) && _CanUsesDodge == true)
        {
            StartCoroutine(RollRight());
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4) && _CanUsesDodge == true)
        {
            StartCoroutine(RollLeft());
        }

    }

    IEnumerator RollLeft() 
    {
        _CanUsesDodge = false;
        _rigidBody.AddForce(-transform.right * 110 * 4);
        yield return new WaitForSeconds(_rollCooldown);
        _CanUsesDodge = true;
    }
    IEnumerator RollRight()
    {
        _CanUsesDodge = false;
        _rigidBody.AddForce(transform.right * 110 * 4);
        yield return new WaitForSeconds(_rollCooldown);
        _CanUsesDodge = true;
    }
}
