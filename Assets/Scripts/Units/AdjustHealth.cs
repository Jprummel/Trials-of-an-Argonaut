using UnityEngine;
using System.Collections;

public class AdjustHealth : MonoBehaviour {

    private float unitHealth;

	// Use this for initialization
	void Start () {
        unitHealth = GetComponent<Unit>().health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        float Damage = other.gameObject.GetComponent<Unit>().damage;
        float currentHealth = this.GetComponent<Unit>().health - Damage;
        this.GetComponent<Unit>().health = currentHealth;
    }

}
