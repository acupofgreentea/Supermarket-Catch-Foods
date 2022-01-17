using UnityEngine;

public class ObjectThrowForce : MonoBehaviour
{
    [SerializeField] private int minForceX;
    [SerializeField] private int maxForceX;
    [SerializeField] private int minForceY;
    [SerializeField] private int maxForceY;
    
    private int throwForceX;
    private int throwForceY;

    private Rigidbody2D rb;

    private void OnEnable() 
    {
        ThrowObject();
    }

    private void FixedUpdate() 
    {
        if(GameManager.Instance.IsGameOver)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    public void SetXDirection(int multiplier)
    {
        minForceX *= multiplier;
        maxForceX *= multiplier;
    }

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void ThrowObject()
    {
        rb.AddForce(RandomForce(), ForceMode2D.Impulse);
    }

    private Vector2 RandomForce()
    {
        throwForceX = Random.Range(minForceX, maxForceX);

        throwForceY = Random.Range(minForceY, maxForceY);

        return new Vector2(throwForceX, throwForceY);
    }

    private void OnDisable() 
    {
        minForceX = Mathf.Abs(minForceX);
        maxForceX = Mathf.Abs(maxForceX);
    }
}
