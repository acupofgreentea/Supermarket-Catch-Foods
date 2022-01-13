using UnityEngine;

public class ObjectThrowForce : MonoBehaviour
{
    [SerializeField] private int maxThrowForce;
    [SerializeField] private int minThrowForce;
    
    private int throwForce;
    private Rigidbody2D rb;

    private void Start() 
    {
        ThrowObject();
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
        throwForce = Random.Range(minThrowForce, maxThrowForce);

        return new Vector2(throwForce, throwForce);
    }
}
