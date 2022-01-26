using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    private GameObject objectToDrag;
    private Vector2 positionMouse;
    private Vector3 screenPosition;
    private RaycastHit2D hit;
    private bool interactive = false;
    private float isDragable = 0;
    private float startPositionZ;
    private IInteractable interactable;

    public bool click = true;

    [SerializeField]
    private Texture2D interactiveCursorTexture;

    void FixedUpdate()
    {
        FindInteractable();
    }

    private void FindInteractable()
    {
        screenPosition = Camera.main.ScreenToWorldPoint(positionMouse);
        
        hit = Physics2D.Raycast(screenPosition, Vector3.forward, Mathf.Infinity);
 
        if(hit.collider != null)
        {
            interactive = true;
            InteractiveCursorTexture();
        }
        else
        {
            interactive = false;
            DefaultCursorTexture();
        }
        
        if(isDragable != 0)
        {
            Debug.Log("Is being dragged");
            objectToDrag.transform.position = new Vector3(screenPosition.x, screenPosition.y, startPositionZ);
        }
    }

    public void Position(InputAction.CallbackContext context)
    {
        positionMouse = context.ReadValue<Vector2>();
    }

    public void Click(InputAction.CallbackContext context)
    {
        if(interactive)
        {
            interactable = hit.transform.gameObject.GetComponent<IInteractable>();
            if(interactable != null)
            {
                interactable.OnClickAction(context);
                //Debug.Log("click");
            }

        }   
    }

    public void DragAndDrop(InputAction.CallbackContext context)
    {
        //Debug.Log(hit.transform.gameObject.tag);
 
        if(hit.collider != null)
        {
            if(hit.transform.gameObject.tag == "DragNDrop")
            {
                objectToDrag = hit.transform.gameObject;
                startPositionZ = objectToDrag.transform.position.z;
                Debug.Log(context.ReadValue<float>());
                isDragable = context.ReadValue<float>();
            }
        }
    }

    private void InteractiveCursorTexture()
    {
        Vector2 hotspot = new Vector2(interactiveCursorTexture.width / 2,0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
    }

    private void DefaultCursorTexture()
    {
        Cursor.SetCursor(default, default, default);
    }

}
