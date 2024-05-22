using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    public int coinCount;
    private string filePath;

    private void Awake()
    {
        manager = this;
        filePath = Path.Combine(Application.persistentDataPath, "coinData.json");
        //Debug.Log("Coin data file path: " + filePath); // Log the file path for debugging
        LoadCoinData();
    }

    public void IncreaseCoin()
    {
        coinCount++;
        GameObject.FindObjectOfType<CoinUI>().UpdateCoin();
    }

    private void OnApplicationQuit()
    {
        SaveCoinData();
    }

    private void SaveCoinData()
    {
        CoinData coinData = new CoinData(coinCount);
        string json = JsonUtility.ToJson(coinData);
        File.WriteAllText(filePath, json);
    }

    private void LoadCoinData()
    {

        // add coins when game end



        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            CoinData coinData = JsonUtility.FromJson<CoinData>(json);
            coinCount += coinData.totalCoins;  // Accumulate total coins
        }
        else
        {
            coinCount = 0;
        }
    }

    // public IEnumerator ChangeSceneAfterSound(string sceneName)
    // {
    //     audioSource.Play(); 
    //     yield return new WaitForSeconds(audioSource.clip.length - 1.2f);  
    //     SceneManager.LoadScene(sceneName);
    // }

}

// public class LevelManager : MonoBehaviour
// {
//     public static LevelManager manager;
//     // public GameObject deatheScreen;
//     public int coinCount;
//     // public bool GameOverCheck;
//     // public Ranking ranking = new Ranking();

//     private void Awake(){
//         manager = this;
//         // SaveSystem.Initialise();
//         // ranking.LoadFromFile("ranking");
//         // GameOverCheck = false;
//     }

//     public void IncreaseCoin(){
//         coinCount ++;
//         GameObject.FindObjectOfType<CoinUI>().UpdateCoin();
//     }
    
//     // public void SaveScore()
//     // {
//     //     GameResult result = new GameResult { Score = score, GameTime = System.DateTime.Now.ToString() };
//     //     ranking.AddResult(result);
//     //     ranking.SaveToFile("ranking");
//     // }

// }