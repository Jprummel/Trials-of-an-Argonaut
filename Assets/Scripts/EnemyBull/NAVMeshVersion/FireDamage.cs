using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            Debug.Log("player damage");
        }
    }
}