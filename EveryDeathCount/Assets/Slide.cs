using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
 
public class Slide : MonoBehaviour, IInteractable
{
    
    public GameObject[] room;
    private GameObject slide;
    private int currentRoomNumber;
    private Vector2 positionMouse;
    private Vector2 screenPosition;
    private bool awake = false;
    private int counter = 0;
    
 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Je suis dans le start");
        if(awake)
        {
            Debug.Log("Non :C");
            slide = room[0];
            slide.SetActive(true);
            room[1].SetActive(true);
            currentRoomNumber = 1;
        }
        else
        {
            while(counter < room.Length)
            {
                Debug.Log("je suis dans la boucle");
                room[counter].SetActive(false);
                counter ++;
            }
        }
     }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(awake);
    }

    public void OnClickAction(InputAction.CallbackContext context)
    {
        Debug.Log("coucouuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
        awake = true;

        if(slide.GetComponent<Collider>() == Physics2D.OverlapPoint(screenPosition))
        {
            room[currentRoomNumber].SetActive(false);
            currentRoomNumber ++;
            if(currentRoomNumber >= room.Length)
            {
                currentRoomNumber = 1;
            }
            room[currentRoomNumber].SetActive(true);  
        }
        
    }

    public void Position(InputAction.CallbackContext context)
    {
        positionMouse = context.ReadValue<Vector2>();
        screenPosition = Camera.main.ScreenToWorldPoint(positionMouse);
    }

}