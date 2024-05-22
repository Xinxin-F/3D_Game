using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public Spawner spawner;
    [SerializeField] private int timeToRespawn;
    [SerializeField] private GameObject objectToRespawn; 

    void Start(){
        spawner = FindObjectOfType<Spawner>();
    }
    
    public void OnTriggerEnter(Collider other){
        if (spawner != null)
        {
            StartCoroutine(RespawnEnemy(objectToRespawn));
        }

        if(other.gameObject.tag == "Hero"){
            //increase coin number 

            Destroy(gameObject);
        }
        
    }   

    IEnumerator RespawnEnemy(GameObject objectToRespawn)
    {
        yield return new WaitForSeconds(timeToRespawn);
        spawner.SpawnObjects(objectToRespawn, 1);
    }
    
}