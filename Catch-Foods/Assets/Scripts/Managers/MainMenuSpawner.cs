using UnityEngine;

public class MainMenuSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private GameObject spawnerObject;

    public void SpawnObject()
    {
        Instantiate(spawnerObject, transform.position, Quaternion.identity);
    }
}
