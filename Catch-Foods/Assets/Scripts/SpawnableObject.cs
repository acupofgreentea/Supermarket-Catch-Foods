using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] private SpawnableObjectsSO[] spawnableObjects;

    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start() 
    {
        // point
        spriteRenderer.sprite = spawnableObjects[GetRandomObjectSO()].sprite;
    }

    private int GetRandomObjectSO()
    {
        return Random.Range(0, spawnableObjects.Length);
    }
}
