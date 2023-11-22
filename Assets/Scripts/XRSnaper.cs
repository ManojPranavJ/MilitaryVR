using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSnaper : XRSocketInteractor
{
   // public string targetTag;
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.GetComponent<Tag>().IsChangable == true;
       
    }
}