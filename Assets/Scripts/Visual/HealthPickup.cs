using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
                    private Health      _health;
    [SerializeField]private float       _healthToAdd;
    [SerializeField]private float       _timeToRespawn;
    [SerializeField]private GameObject  _pickUpObject;
                    private BoxCollider _pickUpCollider;

    void Start()
    {
        _health         = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _pickUpCollider = GetComponent<BoxCollider>();
    }

    public void AddHealth(float value)
    {
        StartCoroutine(PickupCooldown());
        _health.health += _healthToAdd * value;
        if(_health.health > _health.maxHealth)
        {
            _health.health = _health.maxHealth;
        }
    }

    IEnumerator PickupCooldown()
    {
        _pickUpObject.SetActive(false);
        _pickUpCollider.enabled = false;
        yield return new WaitForSeconds(_timeToRespawn);
        RespawnPickup();
    }

    void RespawnPickup()
    {
        _pickUpObject.SetActive(true);
        _pickUpCollider.enabled = true;
    }
}
