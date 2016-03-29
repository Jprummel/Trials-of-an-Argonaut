using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour 
{

    //private PlayerInputs    _input;
    private AdjustHealth        _adjustHealth;
    private PlayerMovement      _movement;
    private HealthPickup        _pickUp;
    private TowerDamage         _towerDamage;
    private ToggleEnableInput   _inputToggle;
    public  Vibration           _vibration;
	
    // Use this for initialization

	void Start () {
        if (this.tag == Tags.PLAYER)
        {
            _movement       = GetComponent<PlayerMovement>();
            _inputToggle = GetComponent<ToggleEnableInput>();
        }

        if(this.tag == Tags.BULL || this.tag == Tags.PLAYER)
        {
            _adjustHealth   = GetComponent<AdjustHealth>();
        }
        if (this.tag == Tags.PICKUP)
        {
            _pickUp         = GetComponent<HealthPickup>();
            
        }
	}
	
    void OnTriggerEnter(Collider other)
    {

        //Player attacking bull
        if (other.tag == Tags.PLAYERWEAPON && this.tag == Tags.BULL)
        {
            Debug.Log(other.transform);
            PlayerAttack checkAttack = other.GetComponentInParent<PlayerAttack>();
            if (checkAttack.IsAttacking())
            {
                _adjustHealth.CalculateNewHealth(other);
                _vibration.Vibrate(1, .25f, "Light");
            }
        }

        if (other.tag == Tags.PLAYERWEAPON && this.tag == Tags.BULLHORNS)
        {
            PlayerAttack checkAttack = other.GetComponentInParent<PlayerAttack>();
            if (checkAttack.IsAttacking())
            {
                _adjustHealth.CalculateNewHealth(other);
                _vibration.Vibrate(1, .25f, "Light");
            }
        }

        //Bull's Charge attack
		if (other.tag == Tags.BULLHORNS && this.tag == Tags.PLAYER) 
		{
			BullBehaviour bullBehaviour = other.GetComponentInParent<BullBehaviour> ();

			if (bullBehaviour.isCharging == true) 
			{
				_adjustHealth.CalculateNewHealth(other);
                _adjustHealth.Knockback(20,other);
                _vibration.Vibrate(0.8f, 0.3f, "Heavy");
                StartCoroutine(_inputToggle.ToggleAllInput(1));
			}
		}

        //Bull hitting pillar in his charge attack
		if(other.gameObject.tag == Tags.PILLAR && this.tag == Tags.BULL)
		{
			
			_towerDamage = other.gameObject.GetComponentInParent<TowerDamage> ();
			BullBehaviour bullBehaviour = this.GetComponentInParent<BullBehaviour> ();
			if (_towerDamage.doDamage == true && bullBehaviour.isCharging == true) {
				_towerDamage.CheckForPlay ();
				_adjustHealth.CalculateNewHealth (other);
                _vibration.Vibrate(1, 1, "Heavy");
			}
		}
        
        //Player health pickup
        if(other.tag == Tags.PLAYER && this.tag == Tags.PICKUP)
        {
            _pickUp.AddHealth(1);
        }

        //Bull health pickup
        if(other.tag == Tags.BULL && this.tag == Tags.PICKUP)
        {
            _pickUp.AddHealth(3);
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Bull's Firebreath attack
        if(other.tag == Tags.BULLFIRE && this.tag == Tags.PLAYER)
        {
            _vibration.Vibrate(1, 1, "Light");
            PlayerBlock checkBlock = GetComponent<PlayerBlock>();
            if (!checkBlock.IsBlocking())
            {
                _adjustHealth.CalculateNewHealth(other);
                AnimStateHandler.AnimStateGeneral(5);
                AnimStateHandler.AnimStateOverride(5);
                StartCoroutine(_inputToggle.ToggleAllInput(1));
            }
        }
    }
}
