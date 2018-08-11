using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeController : MonoBehaviour {
    private int myId;
    public float speed;
    private Rigidbody rb;
    private Transform destination;
    private float distanceToStop = 0.1f;

	// Use this for initialization
	void Awake () {
        destination = GameObject.Find("MoveToPlayer").transform;
        rb = GetComponent<Rigidbody>();
        myId = (int)Random.Range(0, 10);
        if (myId == ShamanController.shamanMain.ShamanNumber)
        {
            ShamanController.shamanMain.Activate();
            destination = ShamanController.shamanMain.evilPosition;
            Vector2 direction = Random.insideUnitCircle.normalized;
            destination.Translate(new Vector3(direction.x * 0.1f, 0.0f, direction.y * 0.1f));
        }
    }
	
	// Update is called once per frame
	void Update () {

        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, destination.position) > distanceToStop)
        {
            transform.LookAt(destination);
            rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        } else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }






}
