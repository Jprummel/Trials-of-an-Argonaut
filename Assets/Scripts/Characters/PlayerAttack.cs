using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private int     _attackState;
    private float   _attackInterval = 1;
    private float   _attackTimer =0;
    private bool    _isAttacking;

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
            //AnimStateHandler.AnimState(*Attack1 Animation*);
            Debug.Log("Attack 1");
            _attackState++;
            TimerReset();
            StartCoroutine(AttackState(5));
        }
        else if (_attackState == 1 && _attackTimer >= _attackInterval)
        {
            //AnimStateHandler.AnimState(*Attack2 Animation*);
            Debug.Log("Attack 2");
            _attackState++;
            TimerReset();
            StartCoroutine(AttackState(1));
        }
        else if (_attackState == 2 && _attackTimer >= _attackInterval)
        {
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
