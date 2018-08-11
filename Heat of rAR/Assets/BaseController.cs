using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {
    public float life;
    public Transform healthBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Damage() {

        life--;
        // Scale inner health bar
        healthBar.localScale = new Vector3(
            life / 10,
            healthBar.localScale.y,
            healthBar.localScale.z
        );
    }
}
