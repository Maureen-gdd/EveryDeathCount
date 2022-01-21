using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableCircle : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("you clicked on the circle");
    }

    void OnEnable()
    {
        InteractableManager.AddToInteractablesEvent.Invoke(transform);
    }

    void OnDisable()
    {
        InteractableManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
