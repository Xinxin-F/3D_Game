using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    // public GameObject deatheScreen;
    public int coinCount;
    // public bool GameOverCheck;
    // public Ranking ranking = new Ranking();

    private void Awake(){
        manager = this;
        // SaveSystem.Initialise();
        // ranking.LoadFromFile("ranking");
        // GameOverCheck = false;
    }

    public void IncreaseCoin(){
        coinCount ++;
        GameObject.FindObjectOfType<CoinUI>().UpdateCoin();
    }
    
    // public void SaveScore()
    // {
    //     GameResult result = new GameResult { Score = score, GameTime = System.DateTime.Now.ToString() };
    //     ranking.AddResult(result);
    //     ranking.SaveToFile("ranking");
    // }

}