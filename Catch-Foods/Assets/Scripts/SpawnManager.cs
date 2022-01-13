using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject throwableObjects;

    private int randomPos;

    private void Start() 
    {
        StartCoroutine(SpawnRate(2f));
    }

    private IEnumerator SpawnRate(float spawnTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        randomPos = Random.Range(0, spawnPoints.Length);

        GameObject obje = Instantiate(throwableObjects, spawnPoints[randomPos].position, Quaternion.identity);

        if(randomPos == 0) {return;}
        
            obje.GetComponent<ObjectThrowForce>().SetXDirection(-1);
    }

}   
