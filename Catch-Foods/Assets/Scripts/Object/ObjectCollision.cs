using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private const string deadZone = "DeadZone";

    private const string cart = "Cart";

    private SpawnableObject spawnableObject;

    private void Awake() 
    {
        spawnableObject = GetComponent<SpawnableObject>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(cart))
        {
            GameManager.Instance.UpdateScore(spawnableObject.Point);

            Destroy(gameObject);
        }

        if(other.CompareTag(deadZone))
        {
            GameManager.Instance.UpdateScore(-spawnableObject.Point);

            Destroy(gameObject);
        }
    }
}
