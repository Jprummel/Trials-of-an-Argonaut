using UnityEngine;
using System.Collections;

public class PlayerBlock : MonoBehaviour {

    private bool                _isBlocking;

	public void Block()
    {
        //StartCoroutine(_inputToggle.ToggleMovementInput(1));
        AnimStateHandler.AnimStateOverride(10);
        _isBlocking = true;
    }

    public void StopBlock()
    {
        AnimStateHandler.AnimStateOverride(0);
        _isBlocking = false;
    }

    public bool IsBlocking()
    {
        return _isBlocking;
    }
}
