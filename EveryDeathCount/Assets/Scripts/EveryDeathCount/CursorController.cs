using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    private Vector2 positionMouse;
    private Vector3 screenPosition;
    private RaycastHit2D hit;
    private bool interactive = false;
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
