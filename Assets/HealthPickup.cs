using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
    private Health _health;
    [SerializeField]private float _healthToAdd;
    [SerializeField]private float _timeToRespawn;

    void Start()
    {
        _health = GetComponent<Health>();
    }

    public void AddHealth(float value)
    {
        _health.health += _healthToAdd * value;
        if(_health.health > _health.maxHealth)
        {
            _health.health = _health.maxHealth;
        }
        PickupCooldown();
    }

    IEnumerator PickupCooldown()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(_timeToRespawn);
        RespawnPickup();

    }

    void RespawnPickup()
    {
        this.gameObject.SetActive(true);
    }
}
