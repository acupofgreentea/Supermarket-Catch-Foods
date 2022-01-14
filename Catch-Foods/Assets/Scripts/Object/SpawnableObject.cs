using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] private SpawnableObjectsSO[] spawnableObjects;

    private SpriteRenderer spriteRenderer;

    private int randomIndeX;

    public int Point{get; set;}

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start() 
    {
        SetObject();
    }

    private void SetObject()
    {
        randomIndeX = Random.Range(0, spawnableObjects.Length);

        spriteRenderer.sprite = spawnableObjects[randomIndeX].sprite;

        Point = spawnableObjects[randomIndeX].point;
    }
}
