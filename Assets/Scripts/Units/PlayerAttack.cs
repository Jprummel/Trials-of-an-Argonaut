using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private int _attackState;
    private float _attackInterval = 1;
    private float _attackTimer =0;

    void Update()
    {
        if(_attackTimer < _attackInterval)
        {
            _attackTimer += Time.deltaTime;
        }
    }

    public void AttackState()
    {
        if(_attackState == 0 && _attackTimer >= _attackInterval)
        {
            //AnimStateHandler.AnimState(*Attack1 Animation*);
            Debug.Log("Attack 1");
            _attackState++;
            TimerReset();
        }
        else if (_attackState == 1 && _attackTimer >= _attackInterval)
        {
            //AnimStateHandler.AnimState(*Attack2 Animation*);
            Debug.Log("Attack 2");
            _attackState++;
            TimerReset();
        }
        else if (_attackState == 2 && _attackTimer >= _attackInterval)
        {
            //AnimStateHandler.AnimState(*Attack3 Animation*);
            Debug.Log("Attack 3");
            _attackState = 0;
            TimerReset();
        }
    }

    void TimerReset()
    {
        _attackTimer = 0;
    }
}
