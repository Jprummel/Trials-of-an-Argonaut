using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private ToggleEnableInput   _inputToggle;
    private PlayerBlock         _block;
    private Damage              _damageAmount;
    private PlayerMovement      _movement;
    private int                 _attackState;
    private bool                _isAttacking;
    private float               _damageBase;
    private Rigidbody           _rigidBody;
    

    void Start()
    {
        _block          = GetComponent<PlayerBlock>();
        _rigidBody      = GetComponent<Rigidbody>();
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _movement       = GetComponent<PlayerMovement>();
        _damageAmount   = GetComponentInChildren<Damage>();
        _damageBase     = _damageAmount.damage;
    }

    public void Attack()
    {
        if (_inputToggle.CanAttack() && !_block.IsBlocking())
        {
            if (_attackState == 0 && !_isAttacking)
            {
                _damageAmount.damage = _damageBase;                     // resets to base damage
                AnimStateHandler.AnimStateOverride(7);
                AnimStateHandler.AnimStateGeneral(7);
                StartCoroutine(AttackState(1.25f,150));
            }
            else if (_attackState == 1 && !_isAttacking)
            {
                _damageAmount.damage = _damageAmount.damage * 1.5f;     //increases power for hit 2
                AnimStateHandler.AnimStateOverride(8);
                AnimStateHandler.AnimStateGeneral(8);
                StartCoroutine(AttackState(1.25f,300));
            }
            else if (_attackState == 2 && !_isAttacking)
            {
                _damageAmount.damage = _damageAmount.damage * 2f;       //increases power for hit 3
                AnimStateHandler.AnimStateOverride(9);
                AnimStateHandler.AnimStateGeneral(9);
                StartCoroutine(AttackState(1.2f,15));
            }
        }
    }

    IEnumerator AttackState(float cooldown, float forwardMovement)
    {
        _isAttacking = true;
        StartCoroutine(_inputToggle.ToggleAllInput(cooldown / 2));
        _rigidBody.AddForce(_movement._playerModel.transform.forward * forwardMovement,0);
        yield return new WaitForSeconds(cooldown);
        _isAttacking = false;
        if (_attackState < 2)
        {
            _attackState++;
        }
        else if (_attackState >= 2)
        {
            _attackState = 0;
        }
        AnimStateHandler.AnimStateOverride(0);
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }
}
