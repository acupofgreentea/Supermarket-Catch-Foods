using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject throwableObjects;

    private int randomPos;

    public float SpawnRate{get; set;}

    private void Start() 
    {
        SpawnRate = 2f;

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

    private IEnumerator SpawnTimer(float spawnTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            
            SpawnObject();
        }
    }
}   
