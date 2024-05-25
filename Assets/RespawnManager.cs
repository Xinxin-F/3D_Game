using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{   
    [SerializeField] private GameObject coinPrefab;
    public int currentCoinNumber = 0;
    private float waitTime = 15f;
    private Spawner spawner;
    [SerializeField] private int maxCoin = 3;
    private int spawnedCoin = 1;
   
    void Start(){
    spawner = FindObjectOfType<Spawner>();  
    StartCoroutine(CoinRespawnRoutine());
    }

    void Update(){
        
    }

    private IEnumerator CoinRespawnRoutine()
    {
        while (true) {
        if(currentCoinNumber == 0 && spawnedCoin < maxCoin)
        {   
            yield return new WaitForSeconds(waitTime);
            spawner.SpawnObjects(coinPrefab, 1);
            spawnedCoin ++;
        }
        else
        {
            yield return null;
        }
        }
    }
}
