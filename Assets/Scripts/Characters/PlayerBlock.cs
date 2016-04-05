using UnityEngine;
using System.Collections;

public class PlayerBlock : MonoBehaviour {

    private bool _isBlocking;

	public void Block()
    {
        AnimStateHandler.AnimStateOverride(10);
        AnimStateHandler.AnimStateGeneral(0);
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
