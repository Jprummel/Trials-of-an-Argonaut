using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {
    BullBehaviour bullBehaviour;
    
	// Use this for initialization
	void Start () {
        bullBehaviour = GetComponentInParent<BullBehaviour> ();
        
    }
	
	// Update is called once per frame
	void Update () {
	if (bullBehaviour.isCharging)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
	}
}
