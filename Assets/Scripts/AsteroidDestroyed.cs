using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
//script for destroying asteroid upon hitting by raycast
public class AsteroidDestroyed : MonoBehaviour
{
    [SerializeField] private GameObject astroidExplosion;
    [SerializeField] private Pose player;

    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupcanvas;


    public void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void AsteroidExplosion()
    {
        Instantiate(astroidExplosion, transform.position, transform.rotation);   //instantiate is used to add objects in to the scene and here it is used to istantiate destroying asteroid
        if(GameController.CurrentGameStatus == GameController.GameState.Playing) 
        {
            //calculate the score 
            float distanceFromPlayer = Vector3.Distance(transform.position, player.position);
            int bonusPoints = (int)distanceFromPlayer;

            int asteroidScore = 10 * bonusPoints;

            // passing asteroid score value to the game controller script
            gameController.UpdatePlayerScore(asteroidScore);



            // instantiate popup canvas in asteroids

            popupcanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
            GameObject asteroidpopup = Instantiate(popupcanvas, transform.position, quaternion.identity); // this is to instantiate a canvas with score*/


            //adjust the scale of the popup
            asteroidpopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 5),
                                                              transform.localScale.y * (distanceFromPlayer / 5),
                                                              transform.localScale.z * (distanceFromPlayer / 5));
        }



        Destroy(this.gameObject);//since this is added to the asteroid istself .....after instantiating destroying object destroying this object is called which will destroy the asteroid itself
    }

}
