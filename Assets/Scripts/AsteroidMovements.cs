using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script for asteroid Movement
public class AsteroidMovements : MonoBehaviour
{
    public float Maxspeed;
    public float Minspeed;


    public float RotationalSpeedMin;
    public float RotationalSpeedMax;
    
    private float RotationalSpeed;
    private float xAngle, yAngle, zAngle;

    private float AsteroidSpeed;

    public Vector3 MovementDirection;
    void Start()
    {
        //this is to specify the speed of the asteroid
      AsteroidSpeed = Random.Range(Maxspeed, Minspeed);

        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);

        RotationalSpeed = Random.Range(RotationalSpeedMax, RotationalSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MovementDirection * Time.deltaTime * AsteroidSpeed, Space.World);
        transform.Rotate(Vector3.up * Time.deltaTime * RotationalSpeed);
    }
}
