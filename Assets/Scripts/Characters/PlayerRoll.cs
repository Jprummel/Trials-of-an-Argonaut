using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour {
    [SerializeField]private int             _rollSpeed = 110;
    [SerializeField]private float           _rollCooldown = 1.3f;
                    private PlayerMovement  _movement;
                    private Rigidbody       _rigidBody;
                    private bool            _CanDodge = true;
                    PlayerSounds _playersounds;



    void Start()
    {
        _playersounds = GetComponent<PlayerSounds>();
        _movement   = GetComponent<PlayerMovement>();
        _rigidBody  = GetComponent<Rigidbody>();
    }

    public void RollX(float value)
    {
        if (_CanDodge)
        {
            if (value > 0)
            {
                AnimStateHandler.AnimStateGeneral(3);
            }
            else if (value < 0)
            {
                AnimStateHandler.AnimStateGeneral(4);
            }

            _rigidBody.AddForce(transform.right * _rollSpeed * value * 4);
            _playersounds.DodgeSound();
            StartCoroutine(RollCooldown());
        }
    }

    public void RollY(float value)
    {
        if (_CanDodge)
        {
            AnimStateHandler.AnimStateGeneral(6);
            _rigidBody.AddForce(-_movement._newForward * _rollSpeed * value * 4);
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
