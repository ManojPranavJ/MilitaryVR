using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XrSocketForGrip : XRSocketInteractor
{
    public string targetTag;
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.CompareTag(targetTag) && interactable.GetComponent<SetTrue>().cansnap == true;
   }
}
