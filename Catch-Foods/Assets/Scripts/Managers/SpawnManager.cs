using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public float SpawnRate{get; set;}

    public bool CanSpawn{get; set;}

    private ISpawner spawner;

    private void OnEnable() 
    {
        GameManager.OnNextLevel += SetSpawnRate;

        GameManager.OnFailedLevel += SetCanSpawn;
    }

    private void Awake() 
    {
        spawner = GetComponent<ISpawner>();

        SpawnRate = 2f;

        CanSpawn = true;
    }

    private void Start() => StartCoroutine(SpawnTimer(SpawnRate));

    private void SetSpawnRate()
    {
        SpawnRate -= 0.2f;

        if(SpawnRate <= 0.5f)
        {
            SpawnRate = 0.5f;
        }  
    }

    public void SetCanSpawn() => CanSpawn = false;

    private IEnumerator SpawnTimer(float spawnTime)
    {
        while(CanSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            
            spawner.SpawnObject();
        }
    }
    
    private void OnDisable() 
    {
        GameManager.OnNextLevel += SetSpawnRate;

        GameManager.OnFailedLevel -= SetCanSpawn;
    }
}
