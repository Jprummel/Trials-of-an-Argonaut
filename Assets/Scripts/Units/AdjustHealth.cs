using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    [SerializeField]private float _deathTimer;
                    private float unitHealth;
    
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == Tags.PLAYERWEAPON && this.tag == Tags.ENEMY || other.tag == Tags.ENEMYWEAPON && this.tag == Tags.PLAYER)
        {
            float Damage = other.gameObject.GetComponent<Damage>().damage;
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
