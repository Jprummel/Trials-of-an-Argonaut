using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public float maxHealth;
    public float health;
    private UnitHealthBar _healthBarPlayer;
    private UnitHealthBar _healthBarBull;
    [SerializeField]
    private bool _player = false;
    [SerializeField]
    private bool _bull = false;

    void Awake()
    {
        if (_player)
        {
            _healthBarPlayer = GameObject.Find("Healthbar Player").GetComponent<UnitHealthBar>();
        }
        if (_bull)
        {
            _healthBarBull = GameObject.Find("Healthbar Bull").GetComponent<UnitHealthBar>();
        }
        health = maxHealth;
    }

    void Update()
    {
        if (_player)
        {
            _healthBarPlayer.HandleBar(health, maxHealth);
        }
        if (_bull)
        {
            _healthBarBull.HandleBar(health, maxHealth);
        }
    }
}
