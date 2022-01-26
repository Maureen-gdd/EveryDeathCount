using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableBackArrow : MonoBehaviour, IInteractable
{
    public GameObject choiceCanvas;
    public GameObject[] interactablesObjects;
    public AudioSource musicBackground;

    public void OnClickAction(InputAction.CallbackContext context)
    {
        musicBackground.Play();
        
        choiceCanvas.SetActive(false);

        foreach (var interactable in interactablesObjects)
        {
            interactable.SetActive(true);
        }
    }
}
