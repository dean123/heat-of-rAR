using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        var hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            var component = hit.transform.GetComponentInParent<Icecube>();
            if (component != null) component.Damage();
        }
    }
}
