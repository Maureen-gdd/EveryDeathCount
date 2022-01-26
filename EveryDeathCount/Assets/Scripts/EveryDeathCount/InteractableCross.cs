using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableCross : MonoBehaviour, IInteractable
{
    public GameObject[] website;
    private bool wait = true;
    private int i = 0;
    
    public void OnClickAction(InputAction.CallbackContext context)
    {
        if(wait)
        {
            if(website.Length > 1)
            {
                wait = false;
                website[i + 1].SetActive(true);

                Destroy(website[i]);
                i++;
                StartCoroutine(Wait());

            }
            else if(website.Length == 1)
            {
                Destroy(website[19]);
            }

        }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        wait = true;

    }
        
    }
}
