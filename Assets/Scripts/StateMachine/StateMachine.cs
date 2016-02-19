using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	private Dictionary<StateID, StateParent> states = new Dictionary<StateID, StateParent> ();
	private StateParent currentState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
			if (currentState != null) 
			{
				currentState.Reason();
				currentState.Act();				
			}
	}


	public void SetState(StateID stateID)
	{
		if (!states.ContainsKey (stateID)) 
		{
			return;
		}

		if (currentState != null) 
		{
			currentState.Leave();
		}

		currentState = states [stateID];

		currentState.Enter ();
	}

	public void AddState(StateID stateID, StateParent state)
	{
		states.Add (stateID, state);

	}
}
