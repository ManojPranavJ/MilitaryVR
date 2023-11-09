using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script for destroying asteroids


public class DestroyKillZone : MonoBehaviour
{
    // public void OnCollisionEnter(Collision collision)
    // {
    //   if(collision.gameObject.tag == "asteroid")    // didnt use this because collision occurs only for rigid body and if the asteroids collides with each it wont be good so we are using ontrigger enter
    // {
    //   Destroy(collision.gameObject);
    //}
    //}



    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Asteroid")
        {
            other.GetComponent<Animator>().SetTrigger("FadeOut");
            Destroy(other.gameObject, 3f);
        }
    }
}