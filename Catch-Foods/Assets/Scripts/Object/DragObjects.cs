using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private bool isDragging;

    private Animator anim;

    private ObjectCollision objectCollision;

    private IDragger dragger;

    private void Awake() 
    {
        anim = GetComponent<Animator>();

        objectCollision = GetComponent<ObjectCollision>();

        dragger = GetComponent<IDragger>();
    }
    
    private void Update() 
    {
        MoveObject();   

        if(GameManager.Instance.IsGameOver)
        {
            SetAnimator(false);
        }
    }

    private void MoveObject()
    {
        if(isDragging)
        {
            dragger.MoveObject();
        }
    }
    
    private void SetAnimator(bool enabled)
    {
        anim.enabled = enabled;
    }

    private void OnMouseDown() 
    {
        isDragging = true;

        dragger.MoveObject();

        SetAnimator(false);
    }

    private void OnMouseUp() 
    {
        isDragging = false;

        if(!objectCollision.IsAddedToCart)
        SetAnimator(true);
    }
}

