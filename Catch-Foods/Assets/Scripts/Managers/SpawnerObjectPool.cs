
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerObjectPool : MonoBehaviour, ISpawner
{
    private ObjectPool<SpawnableObject> objectPool;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private int amountToPool;

    [SerializeField] private GameObject throwableObjects;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private void Start() 
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(throwableObjects);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        return null;
    }
    public void SpawnObject()
    {
        GameObject spawnedObject = GetPooledObject();

        if(spawnedObject != null)
        {
            int randomPos = Random.Range(0, spawnPoints.Length);

            spawnedObject.transform.position = spawnPoints[randomPos].position;

            if(randomPos == 1)
                spawnedObject.GetComponent<ObjectThrowForce>().SetXDirection(-1);
                
            spawnedObject.SetActive(true);

        }
    }
}
