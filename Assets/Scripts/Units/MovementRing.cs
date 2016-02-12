using UnityEngine;
using System.Collections;

public class MovementRing : MonoBehaviour {

	void OnParticleCollision (GameObject other) 
    {
        if (other.tag == "RangeRing")
        { 
            Debug.Log("Collision"); 
        }
	}
}
