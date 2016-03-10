using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    private PlayerInputs    _input;
    private AdjustHealth    _adjustHealth;
    private PlayerMovement  _movement;
    private HealthPickup    _pickUp;
	
    // Use this for initialization
	void Start () {
        if (this.tag == Tags.PLAYER)
        {
            _input      = GetComponent<PlayerInputs>();
            _movement   = GetComponent<PlayerMovement>();
        }

        if(this.tag == Tags.ENEMY || this.tag == Tags.PLAYER)
        {
            _adjustHealth = GetComponent<AdjustHealth>();
        }
        if (this.tag == Tags.PICKUP)
        {
            _pickUp = GetComponent<HealthPickup>();
            
        }
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
		if (other.tag == Tags.BULLHORNS && this.tag == Tags.PLAYER) 
		{
			BullBehaviour bullBehaviour = other.GetComponentInParent<BullBehaviour> ();
			Debug.Log ("Ayylmaokai");
			if (bullBehaviour.isCharging == true) 
			{
				_adjustHealth.CalculateNewHealth (other);
				Debug.Log ("It happend");
                _adjustHealth.Knockback(1000);
			}
		}

        if(other.tag == Tags.PLAYER && this.tag == Tags.PICKUP)
        {
            _pickUp.AddHealth(1);
        }

        if(other.tag == Tags.BULL && this.tag == Tags.PICKUP)
        {
            _pickUp.AddHealth(3);
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
