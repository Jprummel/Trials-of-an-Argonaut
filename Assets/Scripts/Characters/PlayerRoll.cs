using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour {
                    private ToggleEnableInput   _inputToggle;
    [SerializeField]private int                 _rollSpeed = 100;
    [SerializeField]private float               _rollCooldown = 1.3f;
                    private PlayerMovement      _movement;
                    private Rigidbody           _rigidBody;
                    private bool                _CanDodge = true;
                    private PlayerSounds        _playersounds;



    void Start()
    {
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _playersounds   = GetComponent<PlayerSounds>();
        _movement       = GetComponent<PlayerMovement>();
        _rigidBody      = GetComponent<Rigidbody>();
    }

    public void RollX()
    {
        if (_CanDodge)
        {
            StartCoroutine(_inputToggle.ToggleAllInput(0.7f));
            AnimStateHandler.AnimStateGeneral(3);
            AnimStateHandler.AnimStateOverride(3);
            _rigidBody.AddForce(_movement._playerModel.forward * _rollSpeed * 7);
            _rigidBody.AddForce(Vector3.up * 30);
            _playersounds.DodgeSound();
            StartCoroutine(RollCooldown());
        }
    }

    public void RollY(float value)
    {
        if (_CanDodge)
        {
            AnimStateHandler.AnimStateGeneral(6);
            _rigidBody.AddForce(_movement._playerModel.forward * _rollSpeed * value * 4);
            StartCoroutine(RollCooldown());
        }
    }

    IEnumerator RollCooldown()
    {
        _CanDodge = false;
        yield return new WaitForSeconds(_rollCooldown);
        _CanDodge = true;
    }
}
