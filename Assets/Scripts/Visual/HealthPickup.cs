using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
                    private Health      _health;
    [SerializeField]private float       _healthToAdd;
    [SerializeField]private float       _timeToRespawn;
    [SerializeField]private GameObject  _pickUpObject;
    [SerializeField]private GameObject _pickUpParticle;
    [SerializeField]private GameObject _pickUpHearth;
                    private BoxCollider _pickUpCollider;
                    private PlayerSounds _playersounds;

    void Start()
    {
        _playersounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSounds>();
        _health         = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _pickUpCollider = GetComponent<BoxCollider>();
    }

    public void AddHealth(float value)
    {
        if (_health.health < _health.maxHealth)
        {
            StartCoroutine(PickupCooldown());
            _playersounds.PickupSound();
            _health.health += _healthToAdd * value;
        }
    }

    IEnumerator PickupCooldown()
    {
        _pickUpObject.SetActive(false);
        _pickUpCollider.enabled = false;
        _pickUpParticle.SetActive(false);
        _pickUpHearth.SetActive(false);
        yield return new WaitForSeconds(_timeToRespawn);
        RespawnPickup();
    }

    void RespawnPickup()
    {
        _pickUpObject.SetActive(true);
        _pickUpParticle.SetActive(true);
        _pickUpHearth.SetActive(false);
        _pickUpCollider.enabled = true;
    }
}
