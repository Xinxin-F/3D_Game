using UnityEngine;

public class WinLosePage : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;

    private void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }


    public void ActivateLosePanel()
    {   
        losePanel.SetActive(true);
        Time.timeScale = 0f;
        LevelManager.manager.UpdateTotalCoinCount();
    }


    public void ActivateWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        LevelManager.manager.UpdateTotalCoinCount();
    }
}