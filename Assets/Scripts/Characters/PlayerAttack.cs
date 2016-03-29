using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private ToggleEnableInput   _inputToggle;
    private Damage              _damageAmount;
    private PlayerMovement      _movement;
    private int                 _attackState;
    private float               _attackInterval = 1.2f;
    private float               _attackTimer =0;
    private bool                _isAttacking;
    private float               _damageBase;
    private Rigidbody           _rigidBody;
    

    void Start()
    {
        _rigidBody      = GetComponent<Rigidbody>();
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _movement       = GetComponent<PlayerMovement>();
        _damageAmount   = GetComponentInChildren<Damage>();
        _damageBase     = _damageAmount.damage;
    }

    void Update()
    {
        if(_attackTimer < _attackInterval)
        {
            _attackTimer += Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (_inputToggle.CanAttack())
        {
            if (_attackState == 0/* && _attackTimer >= _attackInterval*/)
            {
                _damageAmount.damage = _damageBase;                     // resets to base damage
                AnimStateHandler.AnimStateOverride(7);
                AnimStateHandler.AnimStateGeneral(7);
                //Debug.Log"Attack 1");
                _attackState++;
                TimerReset();
                StartCoroutine(AttackState(1f,150));
            }
            else if (_attackState == 1 /*&& _attackTimer >= _attackInterval*/)
            {
                _damageAmount.damage = _damageAmount.damage * 1.5f;     //increases power for hit 2
                AnimStateHandler.AnimStateOverride(8);
                AnimStateHandler.AnimStateGeneral(8);
                //Debug.Log"Attack 2");
                _attackState++;
                TimerReset();
                StartCoroutine(AttackState(0.4f,300));
            }
            else if (_attackState == 2/* && _attackTimer >= _attackInterval*/)
            {
                _damageAmount.damage = _damageAmount.damage * 2f;       //increases power for hit 3
                AnimStateHandler.AnimStateOverride(9);
                AnimStateHandler.AnimStateGeneral(9);
                //Debug.Log"Attack 3");
                _attackState = 0;
                TimerReset();
                StartCoroutine(AttackState(0.7f,15));
            }
        }
    }

    IEnumerator AttackState(float cooldown, float forwardMovement)
    {
        _isAttacking = true;
        StartCoroutine(_inputToggle.ToggleAllInput(cooldown));
        _rigidBody.AddForce(_movement._newForward * forwardMovement,0);
        yield return new WaitForSeconds(cooldown);
        _isAttacking = false;
        AnimStateHandler.AnimStateOverride(0);
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }

    void TimerReset()
    {
        _attackTimer = 0;
    }
}
