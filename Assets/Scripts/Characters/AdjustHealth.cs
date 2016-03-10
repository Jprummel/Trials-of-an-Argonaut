using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    [SerializeField]private float           _deathTimer;
                    private Rigidbody       _rigidbody;
                    private bool            _canUseInput;

    void Start()
    {
        _rigidbody      = GetComponent<Rigidbody>();
        _canUseInput    = true;
    }

    public void CalculateNewHealth(Collider coll)
    {
        Debug.Log(coll);
        //AnimStateHandler.AnimState(9);
        float Damage = coll.gameObject.GetComponent<Damage>().damage;
        float currentHealth = this.GetComponent<Health>().health;
        currentHealth -= Damage;
        this.GetComponent<Health>().health = currentHealth;

        if (currentHealth <= 0)
        {
            StartCoroutine(DeathTimer());
        }
    }

    IEnumerator DeathTimer()
    {
        //AnimStateHandler.AnimState(11);
        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);        
    }

    public bool CanUseInput()
    {
        return _canUseInput;
    }

    public void Knockback(float value)
    {
        StartCoroutine(DisablePlayer(3));
        _rigidbody.AddForce(Vector3.up * value);
        _rigidbody.AddForce(Vector3.left * value);
        //AnimStateHandler.AnimStateGeneral();
        Debug.Log("Knockback");
    }

    IEnumerator DisablePlayer(float disableTimer)
    {
        _canUseInput = false;
        yield return new WaitForSeconds(disableTimer);
        _canUseInput = true;
    }
}
