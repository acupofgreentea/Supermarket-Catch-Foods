using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private bool isDragging;

    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown() 
    {
        isDragging = true;
        rb.velocity = Vector2.zero;
    }

    private void OnMouseUp() 
    {
        isDragging = false;
    }

    private void Update() 
    {
        if(isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rb.MovePosition(rb.position + mousePosition);
        }
    }

    
}
