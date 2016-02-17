using UnityEngine;
using System.Collections;


public enum StateID
{
	NullState = 0

}


public class EnemyScript : MonoBehaviour {

	private StateMachine _stateMachine;

	void Start () {

		_stateMachine = GetComponent<StateMachine> ();

		MakeStates ();


	//	_stateMachine.SetState (StateID.Idle state);
	}
		
	void MakeStates()
	{
//		_stateMachine.AddState (StateID.Patrolling, GetComponent< Script here > () );



	}

}
