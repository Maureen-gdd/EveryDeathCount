using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableBackArrow : MonoBehaviour, IInteractable
{
    public GameObject choiceCanvas;
    public GameObject[] interactablesObjects;

    public void OnClickAction(InputAction.CallbackContext context)
    {
        choiceCanvas.SetActive(false);

        foreach (var interactable in interactablesObjects)
        {
            interactable.SetActive(true);
        }
    }
}
