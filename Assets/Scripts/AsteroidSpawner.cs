using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation.XRDeviceSimulator;
//script for asteroid spawning
public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] private Vector3 spawnsize; //is a Vector3 that determines the size of the area where asteroids will spawn.
    [SerializeField] private float spawnrate; // is a float representing the time between each asteroid spawn.

    [SerializeField] private GameObject Asteroid;
     private float spawnTimer = 0f; //is a float variable that keeps track of the time elapsed since the last asteroid spawn.


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnsize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime; //It increments spawnTimer by the elapsed time since the last frame using Time.deltaTime.
                                      //If spawnTimer exceeds the spawnrate(the desired spawn interval), it resets spawnTimer and calls the spawnAsteroid function.
        if (spawnTimer > spawnrate) 
        {
           spawnTimer = 0f;
            spawnAseteroid();
        }
    }

    private void spawnAseteroid()
    {
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnsize.x / 2, spawnsize.x / 2), 
                                                              UnityEngine.Random.Range(-spawnsize.y / 2, spawnsize.y / 2), 
                                                              UnityEngine.Random.Range(-spawnsize.z / 2, spawnsize.z / 2));

        GameObject AsteroidModal = Instantiate(Asteroid ,spawnPoint,transform.rotation);
    }
}
