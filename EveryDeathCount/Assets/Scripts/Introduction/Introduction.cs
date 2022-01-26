using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Introduction : MonoBehaviour, IInteractable
{
    public GameObject[] activate;
    public GameObject desactivate;
    public DialogueTrigger dialogTrigger;
    private int i = 0;

    public void OnClickAction(InputAction.CallbackContext context)
    {
        Debug.Log("Introduction");

        while(i < activate.Length)
        {
            activate[i].SetActive(true);
            i++;
        }

        desactivate.SetActive(false);

        dialogTrigger.TriggerDialogue();
    }
}
