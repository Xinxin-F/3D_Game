using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public Spawner spawner;
    [SerializeField] private int timeToRespawn;
    [SerializeField] private GameObject objectToRespawn; 
    public int maxCoin = 3;
    public int spawnedCoin = 1;

    void Start(){
        spawner = FindObjectOfType<Spawner>();
    }
    
    public void OnTriggerEnter(Collider other){
        // if (spawner != null)
        // {
        //     StartCoroutine(RespawnEnemy(objectToRespawn));
        // }

        if(other.gameObject.tag == "Hero"){
            //increase coin number
            LevelManager.manager.IncreaseCoin();
            Destroy(gameObject);
        }

        if (spawner != null)
        {
            StartCoroutine(RespawnEnemy(objectToRespawn));
        }
        
    }   

    IEnumerator RespawnEnemy(GameObject objectToRespawn)
    {
        yield return new WaitForSeconds(timeToRespawn);
        if(spawnedCoin < maxCoin){
            spawner.SpawnObjects(objectToRespawn, 1);
            spawnedCoin++;
        }
    }
    
}