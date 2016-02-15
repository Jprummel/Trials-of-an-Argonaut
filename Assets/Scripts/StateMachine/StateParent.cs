﻿using UnityEngine;
using System.Collections;

public abstract class StateParent : MonoBehaviour {
	
	
	public virtual void Enter ()
	{
	}
	
	public virtual void Leave ()
	{
	} 
	
	public abstract void Act ();
	
	public abstract void Reason ();
	
}