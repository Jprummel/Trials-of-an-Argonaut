using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    [SerializeField]private float _deathTimer;

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

}
