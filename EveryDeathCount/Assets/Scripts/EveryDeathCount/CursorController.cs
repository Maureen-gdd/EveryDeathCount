using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    private Vector2 positionMouse;
    private Vector3 position;
    private RaycastHit2D hit;

    [SerializeField]
    private Texture2D interactiveCursorTexture;

    void FixedUpdate()
    {
        FindInteractable();
    }

    private void FindInteractable()
    {
        position = Camera.main.ScreenToWorldPoint(positionMouse);
        
        hit = Physics2D.Raycast(position, Vector3.forward, Mathf.Infinity);
 
        if(hit.collider != null)
        {
            InteractiveCursorTexture();
        }
        else
        {
            DefaultCursorTexture();
        }
        
    }

    public void Position(InputAction.CallbackContext context)
    {
        positionMouse = context.ReadValue<Vector2>();
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
