using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
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
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 spawnPosition = transform.position;
        for (int i = 0; i < 100; i++) // Try 100 times to find a valid position
        {
            spawnPosition.x = Random.Range(transform.position.x - minDistanceBetweenObjects, transform.position.x + minDistanceBetweenObjects);
            if (!IsPositionOccupied(spawnPosition))
            {
                return spawnPosition;
            }
        }
        return Vector2.zero; // Return zero if no valid position found after 100 tries
    }

    private bool IsPositionOccupied(Vector2 position)
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(position.x, position.y, 0f), minDistanceBetweenObjects);

        foreach (Collider collider in colliders)
        {
            // Check if the collider is not part of the CoinSpawner itself
            if (collider.gameObject.CompareTag("Obstacle")) // Adjust the tag according to your obstacle game object tag
            {
                return true; // Position is occupied by an obstacle
            }
        }

        return false; // Position is not occupied
    }
}