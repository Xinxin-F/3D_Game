using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public RespawnManager respawnManager;

    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        respawnManager.currentCoinNumber++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            LevelManager.manager.IncreaseCoin();
            respawnManager.currentCoinNumber--;
            Destroy(gameObject);
        }
    }
}