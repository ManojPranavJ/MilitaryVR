using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ontargetreached : MonoBehaviour
{
    public float threshold = 0.02f;
    public Transform target;
    public UnityEvent onreached;
    private bool wasreached = false;



    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance< threshold && !wasreached)
        {

            onreached.Invoke();
            wasreached = true;
        }
        else if (distance >= threshold)
        {
            wasreached = false;
        }
    }
}
