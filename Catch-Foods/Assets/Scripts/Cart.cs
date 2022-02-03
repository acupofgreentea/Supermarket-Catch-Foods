using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private float tweenTime;

    [SerializeField] private LeanTweenType leanType;

    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        spriteRenderer.gameObject.transform.localScale = new Vector2(0.5f, 0.5f);

        LeanTween.scale(spriteRenderer.gameObject, Vector2.one, tweenTime).setEase(leanType);
    }
}
