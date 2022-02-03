using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [SerializeField] private AudioEvent objectEvent;

    private const string deadZone = "DeadZone";
    
    private const string cart = "Cart";

    private SpawnableObject spawnableObject;

    private BoxCollider2D boxCollider;

    private Animator anim;
    
    private AudioSource source;

    public bool IsAddedToCart{get; private set;}

    private void Awake() 
    {
        spawnableObject = GetComponent<SpawnableObject>();
        
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        source = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(cart))
        {   
            if(IsAddedToCart) return;
            
            if(GameManager.Instance != null) 
                GameManager.Instance.UpdateScore(spawnableObject.Point);

                objectEvent.PlayAudio(source, 0);

                boxCollider.size = new Vector2(0.3f, 0.3f);

                IsAddedToCart = true;
                
                anim.enabled = false;
        }

        if(other.CompareTag(deadZone))
        {
            if(GameManager.Instance != null)
            GameManager.Instance.UpdateScore(-spawnableObject.Point);

            objectEvent.PlayAudio(source, 1);

            gameObject.SetActive(false);
        }
    }
}
