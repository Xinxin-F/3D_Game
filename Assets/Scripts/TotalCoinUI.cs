using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalCoinUI : MonoBehaviour
{
    private TMP_Text TotalCoinText;

    private void Awake()
    {
        TotalCoinText = GetComponent<TMP_Text>();
        TotalCoinText.text = $"Total Coins: {LevelManager.manager.totalCoinCount}";
    }
    
}