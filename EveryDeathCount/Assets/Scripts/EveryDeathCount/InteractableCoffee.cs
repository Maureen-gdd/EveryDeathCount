using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCoffee : MonoBehaviour, IInteractable
{
    public GameObject ghost;
    private GameObject newGhost;
    private bool instantiate = false;

    void FixedUpdate()
    {
        if(instantiate)
        {
            if(newGhost.transform.position.y > 5.2)
            {
                Destroy(newGhost);
                instantiate = false;
            }

        }
    }

    public void OnClickAction()
    {
        if(instantiate != true)
        {
           newGhost = GameObject.Instantiate(ghost, new Vector3(-7f, 3.3f, 0), ghost.transform.rotation);
           instantiate = true; 
        }
        
    }
}
