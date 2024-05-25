using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    public int totalCoinCount;
    private int sessionCoinCount; 
    private string filePath;

    private void Awake()
    {
        manager = this;
        filePath = Path.Combine(Application.persistentDataPath, "coinData.json");
        LoadCoinData();
    }

    public void IncreaseCoin()
    {
        sessionCoinCount++;
        GameObject.FindObjectOfType<CoinUI>().UpdateCoin();
    }

    public int GetSessionCoinCount()
    {
        return sessionCoinCount; 
    }

    private void OnApplicationQuit()
    {
        SaveCoinData();
    }

    private void SaveCoinData()
    {
        CoinData coinData = new CoinData(totalCoinCount);
        string json = JsonUtility.ToJson(coinData);
        File.WriteAllText(filePath, json);
    }

    private void LoadCoinData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            CoinData coinData = JsonUtility.FromJson<CoinData>(json);
            totalCoinCount = coinData.totalCoins; // Load the total coins
        }
        else
        {
            totalCoinCount = 0;
        }
    }


    public void UpdateTotalCoinCount()
    {
        totalCoinCount += sessionCoinCount; 
        sessionCoinCount = 0; 
        SaveCoinData();
    }

    public void ChangeScene(string name){
        SceneManager.LoadScene(name);
    }
}


    // public IEnumerator ChangeSceneAfterSound(string sceneName)
    // {
    //     audioSource.Play(); 
    //     yield return new WaitForSeconds(audioSource.clip.length - 1.2f);  
    //     SceneManager.LoadScene(sceneName);
    // }



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