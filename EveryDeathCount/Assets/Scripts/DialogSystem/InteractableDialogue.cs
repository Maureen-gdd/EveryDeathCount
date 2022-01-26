using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableDialogue : MonoBehaviour, IInteractable
{
    public DialogueTrigger dialogTrigger;

    public void OnClickAction(InputAction.CallbackContext context)
    {
        dialogTrigger.TriggerDialogue();
    }
}