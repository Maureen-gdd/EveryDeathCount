using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableCoffee : MonoBehaviour, IInteractable
{
    public GameObject ghost;
    private GameObject newGhost;
    private bool instantiate = false;

    void FixedUpdate()
    {
        if(instantiate)
        {
            if(newGhost.transform.position.y > 6.3)
            {
                Destroy(newGhost);
                instantiate = false;
            }

        }
    }

    public void OnClickAction(InputAction.CallbackContext context)
    {
        if(instantiate != true)
        {
           newGhost = GameObject.Instantiate(ghost, new Vector3(-7f, 3.3f, 0), ghost.transform.rotation);
           instantiate = true; 
        }
        
    }
}
