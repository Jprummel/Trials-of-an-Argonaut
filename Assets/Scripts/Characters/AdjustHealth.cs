using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

                    private ToggleEnableInput   _inputToggle;
    [SerializeField]private float               _deathTimer;
                    private Rigidbody           _rigidbody;
                    private bool                _canUseInput;
                    private Vector3             _direction;

    void Start()
    {
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _rigidbody      = GetComponent<Rigidbody>();
        _canUseInput    = true;
    }

    public void CalculateNewHealth(Collider coll)
    {
        float Damage = coll.gameObject.GetComponent<Damage>().damage;
        float currentHealth = this.GetComponent<Health>().health;
        currentHealth -= Damage;
        this.GetComponent<Health>().health = currentHealth;

        if (currentHealth <= 0)
        {
            StartCoroutine(DeathTimer());
        }
        else if (currentHealth > 0)
        {
            AnimStateHandler.AnimStateGeneral(5);
            AnimStateHandler.AnimStateOverride(6);
        }
    }

    IEnumerator DeathTimer()
    {
        StartCoroutine(_inputToggle.ToggleAllInput(999));
        AnimStateHandler.AnimStateGeneral(5);
        AnimStateHandler.AnimStateOverride(5);
        yield return new WaitForSeconds(_deathTimer);
        AnimStateHandler.AnimStateGeneral(6);
        AnimStateHandler.AnimStateOverride(6);
        //Destroy(this.gameObject);        
    }

    public bool CanUseInput()
    {
        return _canUseInput;
    }

    public void Knockback(float value , Collider other)
    {
        float currenthealth = this.GetComponent<Health>().health;
        if (currenthealth > 0)
        {
           StartCoroutine(_inputToggle.ToggleAllInput(1.5f));
        }
        _direction = transform.position - other.transform.position;
        _rigidbody.AddForce(Vector3.up * value * 50);
        _rigidbody.AddForce(_direction * value);
    }
}
