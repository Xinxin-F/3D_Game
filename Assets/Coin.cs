using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Spawner spawner;
    [SerializeField] private int timeToRespawn = 5;
    [SerializeField] private GameObject objectToRespawn;
    public int maxCoin = 3;
    private static int spawnedCoin = 1;

    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            LevelManager.manager.IncreaseCoin();
            if (spawner != null && spawnedCoin < maxCoin)
            {
                StartCoroutine(RespawnCoin());
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator RespawnCoin()
    {
        Debug.Log("Respawn Called");
        yield return new WaitForSeconds(timeToRespawn);
        spawner.SpawnObjects(objectToRespawn, 1);
        Debug.Log("Respawn Coin");
        spawnedCoin++;
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class Coin : MonoBehaviour
// {
//     public Spawner spawner;
//     [SerializeField] private int timeToRespawn;
//     [SerializeField] private GameObject objectToRespawn; 
//     public int maxCoin = 3;
//     public int spawnedCoin = 1;

//     void Start(){
//         spawner = FindObjectOfType<Spawner>();
//     }
    
//     public void OnTriggerEnter(Collider other){
//         // if (spawner != null)
//         // {
//         //     StartCoroutine(RespawnEnemy(objectToRespawn));
//         // }

//         if(other.gameObject.tag == "Hero"){
//             //increase coin number
//             LevelManager.manager.IncreaseCoin();
//             Destroy(gameObject);
//         }

//         if (spawner != null)
//         {
//             StartCoroutine(RespawnEnemy(objectToRespawn));
//         }
        
//     }   

//     IEnumerator RespawnEnemy(GameObject objectToRespawn)
//     {
//         yield return new WaitForSeconds(timeToRespawn);
//         if(spawnedCoin < maxCoin){
//             spawner.SpawnObjects(objectToRespawn, 1);
//             spawnedCoin++;
//         }
//     }
    
// }