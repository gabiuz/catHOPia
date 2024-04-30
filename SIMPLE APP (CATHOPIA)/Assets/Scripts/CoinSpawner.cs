using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 3f;
    public float minDistanceBetweenObjects = 2f; // Adjust as needed

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                Vector2 spawnPosition = transform.position;
                if (!IsPositionOccupied(spawnPosition))
                {
                    GameObject spawnedObject = Instantiate(obj.prefab, spawnPosition, Quaternion.identity);
                    break;
                }
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private bool IsPositionOccupied(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, minDistanceBetweenObjects);

        return colliders.Length > 0;
    }
}
