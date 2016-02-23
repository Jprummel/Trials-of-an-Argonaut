using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
    private Health _health;
    [SerializeField]private float _healthToAdd;
    [SerializeField]private float _timeToRespawn;

    void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void AddHealth(float value)
    {
        _health.health += _healthToAdd * value;
        if(_health.health > _health.maxHealth)
        {
            _health.health = _health.maxHealth;
        }
        StartCoroutine(PickupCooldown());
    }

    IEnumerator PickupCooldown()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(_timeToRespawn);
        RespawnPickup();

    }

    void RespawnPickup()
    {
        gameObject.SetActive(true);
    }
}
