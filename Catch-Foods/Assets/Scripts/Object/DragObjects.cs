using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private bool isDragging;

    private Rigidbody2D rb;

    private Animator anim;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }
    private void Update() 
    {
        MoveObject();   

        if(GameManager.Instance.IsGameOver)
        {
            SetAnimator(false);
        }
    }
    private void OnMouseDown() 
    {
        if(!GameManager.Instance.IsGameOver)
        {
            isDragging = true;
            
            SetAnimator(false);

            rb.velocity = Vector2.zero;
        }
    }

    private void OnMouseUp() 
    {
        isDragging = false;

        SetAnimator(true);
    }

    private void MoveObject()
    {
        if(isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rb.MovePosition(rb.position + mousePosition);
        }
    }

    private void SetAnimator(bool enabled)
    {
        anim.enabled = enabled;
    }

    
}
