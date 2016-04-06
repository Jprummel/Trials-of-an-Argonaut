using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour {
                    private ToggleEnableInput   _inputToggle;
                    private PlayerBlock         _block;
    [SerializeField]private int                 _dodgeSpeed;
    [SerializeField]private float               _dodgeCooldown = 1.3f;
                    private PlayerMovement      _movement;
                    private Rigidbody           _rigidBody;
                    private bool                _CanDodge = true;
                    private PlayerSounds        _playersounds;



    void Start()
    {
        _block          = GetComponent<PlayerBlock>();
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _playersounds   = GetComponent<PlayerSounds>();
        _movement       = GetComponent<PlayerMovement>();
        _rigidBody      = GetComponent<Rigidbody>();
    }

    public void DodgeJump()
    {
        if (_CanDodge && !_block.IsBlocking())
        {
            StartCoroutine(_inputToggle.ToggleAllInput(0.7f));
            AnimStateHandler.AnimStateGeneral(3);
            AnimStateHandler.AnimStateOverride(3);
            _rigidBody.AddForce(_movement._playerModel.forward * _dodgeSpeed * 6);
            _rigidBody.AddForce(Vector3.up * 30);
            _playersounds.DodgeSound();
            StartCoroutine(DodgeCooldown());
        }
    }

    IEnumerator DodgeCooldown()
    {
        _CanDodge = false;
        yield return new WaitForSeconds(_dodgeCooldown);
        _CanDodge = true;
    }
}
