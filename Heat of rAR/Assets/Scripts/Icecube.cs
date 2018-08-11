using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : MonoBehaviour {

    public float health = 100.0f;
    public float maxHealth = 100.0f;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.localScale.y / 2.0f,
            transform.position.z
        );
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0.0f)
        {
            Destroy(gameObject);
            return;
        }

        float relativeHealth = health / maxHealth;
        transform.position = new Vector3(
            transform.position.x,
            (transform.localScale.y * relativeHealth) - (transform.localScale.y / 2.0f),
            transform.position.z
        );
    }

    public void Damage ()
    {
        health--;
    }
}
