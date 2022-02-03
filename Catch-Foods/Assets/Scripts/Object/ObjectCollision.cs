using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public bool IsAddedToCart{get; private set;}
    private const string deadZone = "DeadZone";

    private const string cart = "Cart";

    private SpawnableObject spawnableObject;

    private SoundComponent sound;

    private BoxCollider2D boxCollider;

    private Animator anim;

    private void Awake() 
    {
        spawnableObject = GetComponent<SpawnableObject>();
        sound = GetComponent<SoundComponent>();
        
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(cart))
        {   
            if(IsAddedToCart) {return;}
            
            if(GameManager.Instance != null) 
                GameManager.Instance.UpdateScore(spawnableObject.Point);

                sound.PlaySound(0);

                boxCollider.size = new Vector2(0.3f, 0.3f);

                IsAddedToCart = true;
                
                anim.enabled = false;

            /*if(!IsAddedToCart)
            {
                if(GameManager.Instance != null) 
                GameManager.Instance.UpdateScore(spawnableObject.Point);

                sound.PlaySound(0);

                boxCollider.size = new Vector2(0.3f, 0.3f);

                IsAddedToCart = true;
                
                anim.enabled = false;
            }*/
        }

        if(other.CompareTag(deadZone))
        {
            if(GameManager.Instance != null)
            GameManager.Instance.UpdateScore(-spawnableObject.Point);

            sound.PlaySound(1);

            gameObject.SetActive(false);
        }
    }
}
