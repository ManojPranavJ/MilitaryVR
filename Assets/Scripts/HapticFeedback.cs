using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] private float impulse = 1f;
    [SerializeField] private float time = .5f;
    private void OnEnable()
    {
        grabInteractable.activated.AddListener(SendHapticFeedBack);
    }
    private void OnDisable()
    {
        grabInteractable.activated.RemoveListener(SendHapticFeedBack);
    }
    private void SendHapticFeedBack(ActivateEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<XRBaseController>().SendHapticImpulse(impulse, time);
    }
}
