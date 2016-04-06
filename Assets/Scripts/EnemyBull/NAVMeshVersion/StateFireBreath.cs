using UnityEngine;
using System.Collections;

public class StateFireBreath : StateParent
{
    [SerializeField]private ParticleSystem  FX_fire;
    [SerializeField]private GameObject      Player;
	                        BullBehaviour   bullBehaviour;
	                private int             _stop = 0;
	                private bool            _particle = false;
	                private Vector3         _CurBullPos;

	public override void Leave()
	{
		// on exit
		StartCoroutine(ParticleEnd());
        bullBehaviour.stoppingDistance(1f);
        bullBehaviour.StartCourotine();
    }

	public override void Enter()
	{
		bullBehaviour = GetComponent<BullBehaviour> ();
		//stand still
		bullBehaviour.setSpeed(_stop);
        bullBehaviour.stoppingDistance(20f);
        //look at player
        _CurBullPos = this.gameObject.transform.position;
		//particle fire system
		StartCoroutine(ParticleStart());
		//Player damage zone
		//leave
		StartCoroutine(EndBehaviour());
	}

	public override void Act()
	{
		AnimStateHandler.AnimStateGeneral (3);
		//update
		LookAtPlayer(); // stop if in range
        this.gameObject.transform.position = _CurBullPos;
    }

	public override void Reason()
	{
		//calculation update
	}

	IEnumerator ParticleStart()
	{
		var par = transform.Find("FX_fire").gameObject;
		par.gameObject.SetActive(true);
		yield return new WaitForSeconds(4);
	}

	IEnumerator ParticleEnd()
	{
		yield return new WaitForSeconds(0.1f);
		var par = transform.Find("FX_fire").gameObject;
		par.gameObject.SetActive(false);
	}

	IEnumerator EndBehaviour()
	{
		yield return new WaitForSeconds(3);
		GetComponent<StateMachine>().SetState(StateID.IdleState);
	}

    private void LookAtPlayer()
    {
        if (Player != null)
        {
            Vector3 Botan = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            bullBehaviour.setSpeed(0);
            bullBehaviour.acceleration(101);
            transform.LookAt(Botan);

        }
    }
}