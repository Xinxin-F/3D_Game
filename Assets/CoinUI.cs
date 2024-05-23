using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    private TMP_Text CoinText;

    private void Awake(){
        CoinText = GetComponent<TMP_Text>();
    }

    public void UpdateCoin(){
        CoinText.text = $"Coins: {LevelManager.manager.GetSessionCoinCount()}";
    }

}
