using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

                    private PlayerAttack _attack;
    [SerializeField]private float _deathTimer;
                    private float unitHealth;

    void Start()
    {
        _attack = GetComponent<PlayerAttack>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == Tags.PLAYERWEAPON && this.tag == Tags.ENEMY)
        {
            if (_attack.IsAttacking())
            {
                CalculateNewHealth(other);
            }
        }

        if(other.tag == Tags.ENEMYWEAPON && this.tag == Tags.PLAYER)
        {
            CalculateNewHealth(other);
        }
    }

    void CalculateNewHealth(Collider coll)
    {
        Debug.Log(coll);
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
        //AnimStateHandler.AnimState();
        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);
        
    }

}
