using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragNDrop : MonoBehaviour
{
    private Vector2 positionMouse;
    private Vector2 screenPosition;
    private RaycastHit2D hit;
    private float startPositionZ;
    private float isDragable = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        hit = Physics2D.Raycast(screenPosition, Vector3.forward, Mathf.Infinity);
        screenPosition = Camera.main.ScreenToWorldPoint(positionMouse);

        if(isDragable != 0)
        {
            this.transform.position = new Vector3(screenPosition.x, screenPosition.y, startPositionZ);
        }
    }

    public void Position(InputAction.CallbackContext context)
    {
        positionMouse = context.ReadValue<Vector2>();
    }

    public void DragAndDrop(InputAction.CallbackContext context)
    {
 
        if(hit.collider != null)
        {
            if(hit.transform.gameObject.name == this.name)
            {
               startPositionZ = transform.position.z;
               //Debug.Log(context.ReadValue<float>());
               isDragable = context.ReadValue<float>();
            }
        }
    }
}