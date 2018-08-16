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

        rb = GetComponent<Rigidbody>();
        myId = (int)Random.Range(0, 10);
        //if (myId == ShamanController.shamanMain.ShamanNumber)
        //{
        //    ShamanController.shamanMain.Activate();
        //    destination = ShamanController.shamanMain.evilPosition;
        //    Vector2 direction = Random.insideUnitCircle.normalized;
        //    destination.Translate(new Vector3(direction.x * 0.1f, 0.0f, direction.y * 0.1f));
        //}
        //rb.velocity = new Vector3(-speed, 0, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float step = speed * Time.deltaTime;
        if (/*myId == ShamanController.shamanMain.ShamanNumber*/ false)
        {
            if (Vector3.Distance(transform.position, destination.position) > distanceToStop)
            {

                transform.LookAt(destination);
            }
            //rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);

        }
        else
        {
            transform.position += new Vector3(-step, 0, 0);
        }
    }






}
