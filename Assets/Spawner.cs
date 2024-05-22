using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;
        public int spawnNumber;
    }

    public List<SpawnableObject> spawnPool;
    public GameObject spawnArea;
    public float buffer = 1.0f;
    public int maxRetries = 100; // Maximum number of retries to avoid infinite loops

    void Start()
    {
        foreach (var spawnObject in spawnPool)
        {
            SpawnObjects(spawnObject.prefab, spawnObject.spawnNumber);
        }
    }

    public void SpawnObjects(GameObject objectToSpawn, int numToSpawn)
    {
        Bounds bounds = spawnArea.GetComponent<Renderer>().bounds;

        int spawnedCount = 0;
        int attempts = 0;

        while (spawnedCount < numToSpawn && attempts < maxRetries)
        {
            Vector3 randomPosition = new Vector3(Random.Range(bounds.min.x + buffer, bounds.max.x - buffer),
                                     objectToSpawn.transform.position.y,
                                     Random.Range(bounds.min.z + buffer, bounds.max.z - buffer));

            randomPosition.y = GetObstacleHeight(randomPosition) + objectToSpawn.transform.localScale.y / 2;

            if (!IsOverlapping(randomPosition, objectToSpawn.transform.localScale.x))
            {
                Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
                spawnedCount++;
            }
            attempts++;
        }

        if (spawnedCount < numToSpawn)
        {
            Debug.LogWarning($"Could only spawn {spawnedCount} out of {numToSpawn} {objectToSpawn.name}");
        }
    }

    private float GetObstacleHeight(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return hit.point.y;
        }
        else
        {
            return 0f;
        }
    }

    private bool IsOverlapping(Vector3 position, float objectSize)
    {
        Collider[] colliders = Physics.OverlapSphere(position, objectSize / 2);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != spawnArea)
            {
                return true;
            }
        }

        return false;
    }
}









//// the number to spawn does not meet requirement
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawner : MonoBehaviour
// {
//     [System.Serializable]
//     public class SpawnableObject
//     {
//         public GameObject prefab;
//         public int spawnNumber;
//     }

//     public List<SpawnableObject> spawnPool;
//     public GameObject spawnArea;

//     void Start()
//     {
//         foreach (var spawnObject in spawnPool)
//         {
//             SpawnObjects(spawnObject.prefab, spawnObject.spawnNumber);
//         }
//     }

//     public float buffer = 1.0f;
//     public void SpawnObjects(GameObject objectToSpawn, int numToSpawn)
//     {
//         Bounds bounds = spawnArea.GetComponent<Renderer>().bounds;

//         for (int i = 0; i < numToSpawn; i++)
//         {
//             // Vector3 randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
//             //                                      objectToSpawn.transform.position.y,
//             //                                      Random.Range(bounds.min.z, bounds.max.z));

//             Vector3 randomPosition = new Vector3(Random.Range(bounds.min.x + buffer, bounds.max.x - buffer),
//                                      objectToSpawn.transform.position.y,
//                                      Random.Range(bounds.min.z + buffer, bounds.max.z - buffer));

//             randomPosition.y = GetObstacleHeight(randomPosition) + objectToSpawn.transform.localScale.y / 2;

//             if (!IsOverlapping(randomPosition, objectToSpawn.transform.localScale.x))
//             {
//                 Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
//             }
//         }
//     }

//     private float GetObstacleHeight(Vector3 position)
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
//         {
//             return hit.point.y;
//         }
//         else
//         {
//             return 0f;
//         }
//     }

//     private bool IsOverlapping(Vector3 position, float objectSize)
//     {
//         Collider[] colliders = Physics.OverlapSphere(position, objectSize / 2);

//         foreach (Collider collider in colliders)
//         {
//             if (collider.gameObject != spawnArea)
//             {
//                 return true;
//             }
//         }

//         return false;
//     }
// }