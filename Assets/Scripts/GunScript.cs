using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script for gun mechanics
public class GunScript : MonoBehaviour
{
    //animation
    [SerializeField] private Animator GunAnimator;

    //sfx
    [SerializeField] private AudioSource GunSource;
    [SerializeField] private AudioClip GunClip;
    //raycast
    public Transform raycastPoint;
    private RaycastHit hit;

    // bullet instantiate 
   [SerializeField] private GameObject bulletPrefab;
    

    private void Awake()
    {
        GunSource = GetComponent<AudioSource>();//for audio
    }

    public void gunFired()
    {
        //animation for the gun trigger
        GunAnimator.SetTrigger("Fire"); //this is how animation is called by a function 

        //Playaudio
        GunSource.PlayOneShot(GunClip);//play the clip

        // instantiate bullet
      Instantiate(bulletPrefab, raycastPoint.position,raycastPoint.rotation);
        
        

        //for raycast
        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, 800f))  // if is used to check if the raycast has hit any objects
                                                                                          //out hit: This parameter is an output variable that will store information about the detected collision, if any.
        {
            if (hit.transform.GetComponent<AsteroidDestroyed>() != null )  // The != null comparison checks if the returned component reference is not null. If the component is not null, it means that the object has an AsteroidDestroyed component attached to it, indicating that the object is an asteroid. In that case, the condition evaluates to true, and the code block inside the if statement is executed
            {
                hit.transform.GetComponent<AsteroidDestroyed>().AsteroidExplosion();// hit stores the data of raycasting hiting a object..........and calling the function from the code in the asteroid 
            }
            else if (hit.transform.GetComponent<IRayCastInterface>() != null ) 
            {
                hit.transform.GetComponent<IRayCastInterface>().HitByRaycast();
            
            
            }
        }

    }
}


/*  */   // null reference error came in this code 




/*if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, 800f))  // if is used to check if the raycast has hit any objects
       {                                                                                //out hit: This parameter is an output variable that will store information about the detected collision, if any.
           if (hit.transform.CompareTag("Asteroid"))
           {
               AsteroidDestroyed asteroidDestroyed = hit.transform.GetComponent<AsteroidDestroyed>();
               if (asteroidDestroyed != null)
               {
                   asteroidDestroyed.AsteroidExplosion();
               }
           }
       }*/