using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private Transform[] spawnplace;
    [SerializeField] private GameObject[] food;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(food[Random.Range(0, 5)], spawnplace[Random.Range(0, 2)].position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
