using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
 
public class Slideshow : MonoBehaviour, IInteractable
{
    public GameObject[] room;
    public GameObject interactable;
    private bool wait = false;
    private int counter = 0;
    private Vector3 startPosition;
    private Vector3 startScale;

    public void OnClickAction(InputAction.CallbackContext context)
    {
        Debug.Log("click on the tablet");
        Debug.Log(wait);
        if(counter == 0 && !wait)
        {
            Debug.Log("Awake");
            startPosition = transform.position;
            startScale = transform.localScale;
            //Debug.Log("Before");
            //Debug.Log(startPosition);
            //Debug.Log(startScale);
            Vector3 newScale = startScale * 4.4f;
            transform.localScale = newScale;
            transform.position = new Vector3(0.5f, 0f, 0f);
            //Debug.Log("After");
            //Debug.Log(transform.position);
            //Debug.Log(transform.localScale);
            interactable.SetActive(false);
            room[0].SetActive(true);
            room[1].SetActive(true);
            StartCoroutine(Wait());

            counter ++;
        }
        else if(counter == 1 && wait)
        {
            //Debug.Log("Turn off");
            transform.localScale = startScale;
            transform.position = startPosition;
            interactable.SetActive(true);
            for (int i = 0; i < room.Length; i++)
            {
                room[i].SetActive(false);
            }
            StartCoroutine(Wait());
            counter = 0;
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        if(wait)
        {
            wait = false;
        }
        else
        {
            wait = true;
        }

    }

}
