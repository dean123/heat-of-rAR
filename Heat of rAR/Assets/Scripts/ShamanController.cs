using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanController : MonoBehaviour {
    public static ShamanController shamanMain;


    public readonly int ShamanNumber = 7;
    private bool activated = false;
    public Transform evilPosition;

    //! Makes sure that there is only one instance of the static class object
    private void Awake()
    {
            shamanMain = this;
    }


	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()
    {
        if (!activated)
        {

            activated = true;
            float x = Random.Range(-0.5f, 0.5f);
            float z = Random.Range(-0.3f, 0.3f);
            Vector3 pos = new Vector3(x, 0.0f, z);
            transform.localPosition = pos;
            evilPosition = transform;
    
        }

    }
}
