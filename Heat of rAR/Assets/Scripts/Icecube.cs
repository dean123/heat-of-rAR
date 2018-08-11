using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : MonoBehaviour {

    [SerializeField]
    private float health = 100.0f;

    [SerializeField]
    private float maxHealth = 100.0f;

	// Use this for initialization
	void Start ()
    {
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
        transform.localScale = new Vector3(
            transform.localScale.x,
            relativeHealth,
            transform.localScale.z
        );
    }

    public void Damage ()
    {
        health--;
    }
}
