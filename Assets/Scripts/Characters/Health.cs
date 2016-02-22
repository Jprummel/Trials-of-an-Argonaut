using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float maxHealth;
    public float health;

    void Start()
    {
        health = maxHealth;
    }
}
