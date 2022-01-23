using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableSlide2 : MonoBehaviour, IInteractable
{
    public GameObject[] room;
    private int currentRoomNumber;

    void Start()
    {
        currentRoomNumber = 0;
    }

    public void OnClickAction(InputAction.CallbackContext context)
    {
        room[currentRoomNumber].SetActive(false);
        currentRoomNumber ++;
        if(currentRoomNumber >= room.Length)
        {
            currentRoomNumber = 0;
        }
        room[currentRoomNumber].SetActive(true);  
    }
}
