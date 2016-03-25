using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    [SerializeField]private float           _deathTimer;
                    private Rigidbody       _rigidbody;
                    private bool            _canUseInput;
                    private Vector3         _direction;

    void Start()
    {
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
            AnimStateHandler.AnimStateGeneral(8);
        }
    }

    IEnumerator DeathTimer()
    {
        _canUseInput = false;
        AnimStateHandler.AnimStateGeneral(8);
        yield return new WaitForSeconds(_deathTimer);
        AnimStateHandler.AnimStateGeneral(9);
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
            StartCoroutine(DisablePlayer(2));
        }
        _direction = transform.position - other.transform.position;
        _rigidbody.AddForce(Vector3.up * value * 50);
        _rigidbody.AddForce(_direction * value);
    }

    IEnumerator DisablePlayer(float disableTimer)
    {
        _canUseInput = false;
        yield return new WaitForSeconds(disableTimer);
        _canUseInput = true;
    }
}
