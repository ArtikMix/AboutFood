using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private Transform[] spawnplace;
    [SerializeField] private GameObject[] food;
    private float spawn_time;

    private void Start()
    {
        spawn_time = 3.5f;
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(food[Random.Range(0, 4)], spawnplace[Random.Range(0, 2)].position, Quaternion.identity);
            if (spawn_time >= 1f)
                spawn_time -= 0.01f;
            yield return new WaitForSeconds(spawn_time);
        }
    }
}
