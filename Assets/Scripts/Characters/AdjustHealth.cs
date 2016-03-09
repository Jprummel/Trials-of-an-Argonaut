using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    [SerializeField]private float       _deathTimer;
                    private Rigidbody   _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

    public void Knockback(float value)
    {
        //_rigidbody.AddForce(Vector3.forward * Time.deltaTime * value);
        _rigidbody.AddForce(Vector3.left * value);
        Debug.Log("Knockback");
    }

}
