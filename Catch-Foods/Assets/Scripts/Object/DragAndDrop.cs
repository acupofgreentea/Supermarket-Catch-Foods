using UnityEngine;

public class DragAndDrop : MonoBehaviour, IDragger
{
    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Dragging()
    {
        if(!GameManager.Instance.IsGameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }
    public void MoveObject()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.MovePosition(rb.position + mousePosition);
    }
}
