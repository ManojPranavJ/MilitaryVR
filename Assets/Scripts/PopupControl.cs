using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
    private void Update()
    {
        // rotate the canvas towards the camera
        transform.LookAt(Camera.main.transform);
        //destroy the canva
        Destroy(this.gameObject, 3f);
    }

}
