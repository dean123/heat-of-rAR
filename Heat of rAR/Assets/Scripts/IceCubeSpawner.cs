﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject icecubePrefab;

    [SerializeField]
    private GameObject spawnArea;

    [SerializeField]
    private float spawnTime = 1.0f;

    [SerializeField]
    private float gameWidth = 10.0f;

    [SerializeField]
    private float gameHeight = 10.0f;

    private float lastSpawnTime;
    private bool firstCube = true;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - lastSpawnTime > spawnTime || firstCube)
        {
            float x = Random.Range(-gameHeight / 2.0f, gameHeight / 2.0f);
            GameObject icecube = Instantiate(icecubePrefab, transform);
            icecube.transform.localPosition = new Vector3(x, 0.0f, 0.0f);

            lastSpawnTime = Time.time;
            firstCube = false;
        }
	}
}
