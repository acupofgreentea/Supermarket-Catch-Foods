using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject throwableObjects;

    private int randomPos;

    public float SpawnRate{get; set;}

    public bool CanSpawn{get; set;}

    private void OnEnable() 
    {
        GameManager.OnNextLevel += SetSpawnRate;

        GameManager.OnFailedLevel += SetCanSpawn;
    }

    private void Start() 
    {
        SpawnRate = 2f;

        CanSpawn = true;

        StartCoroutine(SpawnTimer(SpawnRate));
    }

    private void SpawnObject()
    {
        randomPos = Random.Range(0, spawnPoints.Length);

        GameObject obje = Instantiate(throwableObjects, spawnPoints[randomPos].position, Quaternion.identity);

        if(randomPos == 0) {return;}
        
            obje.GetComponent<ObjectThrowForce>().SetXDirection(-1);
    }

    private void SetSpawnRate()
    {
        SpawnRate -= 0.2f;
    }

    public void SetCanSpawn()
    {
        CanSpawn = false;
    }

    private IEnumerator SpawnTimer(float spawnTime)
    {
        while(CanSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            
            SpawnObject();
        }
    }
    
    private void OnDisable() 
    {
        GameManager.OnNextLevel += SetSpawnRate;

        GameManager.OnFailedLevel -= SetCanSpawn;
    }
}   
