using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatController : MonoBehaviour {
    // Objects needed to start the game
    public GameObject CanvasUI;
    public GameObject EnemyBase;
    public GameObject PlaneFinder;

    public LayerMask layerMask;

    private float currentHitDistance = 100;
    private float radius = 0.05f;

    private void FixedUpdate()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            Icecube component = hit.transform.GetComponentInParent<Icecube>();
            currentHitDistance = hit.distance;
            if (component != null) component.Damage();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * currentHitDistance, radius);
    }

    public void StartGame()
    {
        CanvasUI.SetActive(true);
        EnemyBase.SetActive(true);
        PlaneFinder.SetActive(false);
    }
}
