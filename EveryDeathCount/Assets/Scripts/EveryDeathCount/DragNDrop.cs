using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragNDrop : MonoBehaviour
{
    private Collider2D objectCollider;
    private Vector2 positionMouse;
    private Vector2 screenPosition;
    private Vector2 startPosition;
    private float isDragable = 0;
    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        screenPosition = Camera.main.ScreenToWorldPoint(positionMouse);
        if(isDragable != 0 && isDragging)
        {
            this.transform.position = screenPosition;
        }
    }

    public void Position(InputAction.CallbackContext context)
    {
        positionMouse = context.ReadValue<Vector2>();
    }

    public void DragAndDrop(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<float>());
        isDragable = context.ReadValue<float>();
        startPosition = screenPosition;
        if(objectCollider == Physics2D.OverlapPoint(screenPosition))
        {
            isDragging = true;
        }
        else
        {
            isDragging = false;
        }
    }
}