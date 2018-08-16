using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatController : MonoBehaviour {


    private void FixedUpdate()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Icecube component = hit.transform.GetComponentInParent<Icecube>();
            if (component != null) component.Damage();
        }
    }
}
