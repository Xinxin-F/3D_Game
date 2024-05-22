// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainMenuPage : MonoBehaviour
// {
//     public void ChangeScene(string name){
//         yield return new WaitForSeconds(1f);
//         Time.timeScale = 1f;
//         SceneManager.LoadScene(name);
//     }

//     public void QuitGame(){
//         Application.Quit();
//     }

//     // public AudioSource audio;

//     // public void playButton(){
//     //     audio.Play();
//     // }
// }


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPage : MonoBehaviour
{
    public AudioSource audioSource;

    public void ChangeScene(string name)
    {
        StartCoroutine(ChangeSceneAfterSound(name));
    }

    public IEnumerator ChangeSceneAfterSound(string sceneName)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length - 1.2f); 
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}