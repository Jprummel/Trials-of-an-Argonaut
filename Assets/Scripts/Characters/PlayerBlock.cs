using UnityEngine;
using System.Collections;

public class PlayerBlock : MonoBehaviour {

    private bool _isBlocking;

	public void Block()
    {
        AnimStateHandler.AnimStateOverride(4);
        _isBlocking = true;
    }

    public bool IsBlocking()
    {
        return _isBlocking = true;
    }
}
