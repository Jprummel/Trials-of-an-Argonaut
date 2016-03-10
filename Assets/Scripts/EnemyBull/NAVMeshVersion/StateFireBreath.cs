using UnityEngine;
using System.Collections;

public class StateFireBreath : StateParent
{
    BullBehaviour bullBehaviour;
    private int _stop = 0;
    private bool _particle = false;
    [SerializeField]private ParticleSystem FX_fire;

    public override void Leave()
    {
        // on exit
        StartCoroutine(ParticleEnd());
        Debug.Log("Im Leaving");
    }

    public override void Enter()
    {
        bullBehaviour = GetComponent<BullBehaviour> ();
        Debug.Log("Im hot");
        //stand still
        bullBehaviour.setSpeed(_stop);
        transform.LookAt(bullBehaviour.targetPos);
        //particle fire system
        StartCoroutine(ParticleStart());
        //Player damage zone
        
        //leave
        StartCoroutine(EndBehaviour());
    }

    public override void Act()
    {
        //update
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

}
