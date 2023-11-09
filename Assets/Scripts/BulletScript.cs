using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
    }

    
}
