using UnityEngine;
using System.Collections;

public class ToggleEnableInput : MonoBehaviour {

    private bool _canAttack     = true;
    private bool _canMove       = true;

    public IEnumerator ToggleAttackInput(float disabledTime)
    {
        _canAttack = false;
        yield return new WaitForSeconds(disabledTime);
        _canAttack = true;
    }

    public IEnumerator ToggleMovementInput(float disabledTime)
    {
        _canMove = false;
        yield return new WaitForSeconds(disabledTime);
        _canMove = true;
    }

    public IEnumerator ToggleAllInput(float disabledTime)
    {
        _canAttack  = false;
        _canMove    = false;
        yield return new WaitForSeconds(disabledTime);
        _canAttack  = true;
        _canMove    = true;
    }

    public bool IsDead()
    {
        return !_canAttack & !_canMove;
    }

    public bool CanAttack()
    {
        return _canAttack;
    }

    public bool CanMove()
    {
        return _canMove;
    }
}
