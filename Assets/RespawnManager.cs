// using System.Collections;
// using UnityEngine;

// public class RespawnManager : MonoBehaviour
// {
//     public static RespawnManager Instance { get; private set; }

//     void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     public void StartRespawnCoroutine(GameObject objectToRespawn, Spawner spawner, int timeToRespawn)
//     {
//         StartCoroutine(RespawnCoin(objectToRespawn, spawner, timeToRespawn));
//     }

//     private IEnumerator RespawnCoin(GameObject objectToRespawn, Spawner spawner, int timeToRespawn)
//     {
//         Debug.Log("Respawn Called");
//         yield return new WaitForSeconds(timeToRespawn);
//         spawner.SpawnObjects(objectToRespawn, 1);
//         Debug.Log("Respawn Coin");
//         Coin.spawnedCoin++;
//     }
// }
