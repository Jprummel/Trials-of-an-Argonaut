using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    private AdjustHealth _adjustHealth;
	// Use this for initialization
	void Start () 
    {
        _adjustHealth = GetComponent<AdjustHealth>();
	}
	
    void OnTriggerEnter(Collider other)
    {

        //Player attacking bull
        if (other.tag == Tags.PLAYERWEAPON && this.tag == Tags.ENEMY)
        {
            PlayerAttack checkAttack = other.GetComponentInParent<PlayerAttack>();
            if (checkAttack.IsAttacking())
            {
                _adjustHealth.CalculateNewHealth(other);
            }
        }

        if (other.tag == Tags.ENEMYWEAPON && this.tag == Tags.PLAYER)
        {
            _adjustHealth.CalculateNewHealth(other);
        }

        if(other.tag == Tags.BULLFIRE && this.tag == Tags.PLAYER)
        {
            PlayerBlock checkBlock = GetComponent<PlayerBlock>();
            if (!checkBlock.IsBlocking())
            {
                _adjustHealth.CalculateNewHealth(other);
            }
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == Tags.PILLAR && this.tag == Tags.BULL)
        {
            //Damage bull
        }
    }
}
