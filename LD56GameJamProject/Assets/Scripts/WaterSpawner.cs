using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    public float waterDelayTime = 3f;

    void Update()
    {
        StartCoroutine(waterDelay()); 
    }

    private IEnumerator waterDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(waterDelayTime);

        while (true)
        {
            yield return wait;

            Instantiate(waterPrefab, transform.position, Quaternion.identity);
        }
    }
}
