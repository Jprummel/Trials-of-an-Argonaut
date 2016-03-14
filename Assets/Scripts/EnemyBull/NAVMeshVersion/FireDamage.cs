using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

    private Health _Health;
    Damage playerdamage;
	// Use this for initialization
	void Start () {
        GameObject thePlayer = GameObject.Find("Player");
        _Health = thePlayer.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider obj)
    {
        playerdamage = GetComponent<Damage>();
        if (obj.tag == "Player")
        {
            _Health.health -= 0.1f;
            Debug.Log("HGF");


         
        }
    }
}