using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private Damage  _damageAmount;
    private int     _attackState;
    private float   _attackInterval = 1;
    private float   _attackTimer =0;
    private bool    _isAttacking;
    private float   _damageBase;

    void Start()
    {
        _damageAmount = GetComponent<Damage>();
        _damageBase = _damageAmount.damage;
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
        if(_attackState == 0 && _attackTimer >= _attackInterval)
        {
            _damageAmount.damage = _damageBase; // resets to base damage
            //AnimStateHandler.AnimState(*Attack1 Animation*);
            Debug.Log("Attack 1");
            _attackState++;
            TimerReset();
            StartCoroutine(AttackState(5));
        }
        else if (_attackState == 1 && _attackTimer >= _attackInterval)
        {
            _damageAmount.damage = _damageAmount.damage * 1.5f; //increases power for hit 2
            //AnimStateHandler.AnimState(*Attack2 Animation*);
            Debug.Log("Attack 2");
            _attackState++;
            TimerReset();
            StartCoroutine(AttackState(1));
        }
        else if (_attackState == 2 && _attackTimer >= _attackInterval)
        {
            _damageAmount.damage = _damageAmount.damage * 2f; //increases power for hit 3
            //AnimStateHandler.AnimState(*Attack3 Animation*);
            Debug.Log("Attack 3");
            _attackState = 0;
            TimerReset();
            StartCoroutine(AttackState(1));
        }
    }

    IEnumerator AttackState(float cooldown)
    {
        _isAttacking = true;
        Debug.Log(_isAttacking);
        yield return new WaitForSeconds(cooldown);
        _isAttacking = false;
        Debug.Log(_isAttacking);
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
