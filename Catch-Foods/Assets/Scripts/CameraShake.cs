using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration;

    public static bool CanShake{get; set;}

    private void Update() 
    {
        if(CanShake)
            StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        Vector3 startPos = transform.position;

        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            transform.position = startPos + Random.insideUnitSphere / 10;

            yield return null;

            CanShake = false;
        }

        transform.position = startPos;
        
    }
}
