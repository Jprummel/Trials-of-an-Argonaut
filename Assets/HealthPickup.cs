using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
    private Health _playerHealth;
    [SerializeField]private float _healthToAdd;
    [SerializeField]private float _timeToRespawn;

    void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

    public void AddHealth()
    {
        _playerHealth.health += _healthToAdd;
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
