using UnityEngine;

public class ObjectSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject throwableObjects;

    private int randomPos;
    
    public void SpawnObject()
    {
        randomPos = Random.Range(0, spawnPoints.Length);

        GameObject spawnedObject = Instantiate(throwableObjects, spawnPoints[randomPos].position, Quaternion.identity);

        if(randomPos == 1)
            spawnedObject.GetComponent<ObjectThrowForce>().SetXDirection(-1);
    }
}
