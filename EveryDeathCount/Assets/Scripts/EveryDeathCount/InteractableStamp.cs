using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableStamp : MonoBehaviour, IInteractable
{
    public GameObject[] interactableObjects;
    public GameObject choiceCanvas;

    public void OnClickAction(InputAction.CallbackContext context)
    {
        // Disable all interactable objects
        foreach (var interactable in interactableObjects)
        {
            interactable.SetActive(false);
        }

        // Enable choice canvas
        choiceCanvas.SetActive(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

}
