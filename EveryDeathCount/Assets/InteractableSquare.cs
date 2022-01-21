using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSquare : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("you clicked on the square");
    }
}
