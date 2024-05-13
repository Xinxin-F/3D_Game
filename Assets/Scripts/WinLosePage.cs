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
    }


    public void ActivateWinPanel()
    {
        winPanel.SetActive(true);
    }
}