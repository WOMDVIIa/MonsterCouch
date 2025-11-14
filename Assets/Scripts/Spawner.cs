using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    int enemiesToSpawn = 1000;
    float spawningDuration = 2.0f;

    IEnumerator Start()
    {
        float interval = spawningDuration / (float)enemiesToSpawn;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSecondsRealtime(interval);
        }
    }
}
