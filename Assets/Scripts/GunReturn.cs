using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunReturn : MonoBehaviour
{
    private Pose originPose;
    private XRGrabInteractable grabInteractable;
  
    public void Awake()
    {
      
        grabInteractable = GetComponent<XRGrabInteractable>();
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }


    public void OnEnable()
    {
        grabInteractable.selectExited.AddListener(GunBackToOrigin);
    }
    public void OnDisable()
    {
        grabInteractable.selectExited.RemoveAllListeners();
    }

    private void GunBackToOrigin(SelectExitEventArgs arg0)
    {
        
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}
