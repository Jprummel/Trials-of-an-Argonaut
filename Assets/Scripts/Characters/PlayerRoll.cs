using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour {
    [SerializeField]private int         _rollSpeed = 110;
    [SerializeField]private float       _rollCooldown = 1.3f;
                    private Rigidbody   _rigidBody;
                    private bool        _CanDodge = true;
    
    


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void RollX(float value)
    {
        if (_CanDodge)
        {
            
                AnimStateHandler.AnimStateGeneral(6);
            
            /*else if (value < 0)
            {
                AnimStateHandler.AnimStateGeneral(7);
            }*/

            _rigidBody.AddForce(transform.right * _rollSpeed * value * 4);
            StartCoroutine(RollCooldown());
        }
    }

    public void RollY(float value)
    {
        if (_CanDodge)
        {
            AnimStateHandler.AnimStateGeneral(6);
            _rigidBody.AddForce(-transform.forward * _rollSpeed * value * 4);
            StartCoroutine(RollCooldown());
        }
    }

    IEnumerator RollCooldown()
    {
        _CanDodge = false;
        yield return new WaitForSeconds(_rollCooldown);
        _CanDodge = true;
    }
}
