using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableSlide : MonoBehaviour, IInteractable
{
    public GameObject[] room;
    private int currentRoomNumber;
    private bool wait = true;

    void Start()
    {
        currentRoomNumber = 0;
    }

    public void OnClickAction(InputAction.CallbackContext context)
    {
            if(wait)
            {
                Debug.Log("ça chaaaange");
                wait = false;
                room[currentRoomNumber].SetActive(false);
                currentRoomNumber ++;
                if(currentRoomNumber >= room.Length)
                {
                    currentRoomNumber = 0;
                }
                room[currentRoomNumber].SetActive(true);
                StartCoroutine(Wait());

            }
        
          
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        wait = true;

    }
}
