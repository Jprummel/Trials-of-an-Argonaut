using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    [SerializeField]private float _deathTimer;
                    private float unitHealth;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerUnit" && this.tag == "EnemyUnit" || other.tag == "EnemyUnit" && this.tag =="PlayerUnit")
        {
            float Damage = other.gameObject.GetComponent<Unit>().damage;
            float currentHealth = this.GetComponent<Unit>().health;
            currentHealth -= Damage;
            this.GetComponent<Unit>().health = currentHealth;

            if (currentHealth <= 0)
            {
                StartCoroutine(DeathTimer());
            }
        }

    }

    IEnumerator DeathTimer()
    {
        //AnimStateHandler.AnimState();
        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);
        
    }

}
