using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Credit()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void CreditAsset()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void HowToPlay()
    { 
        SceneManager.LoadSceneAsync(2);
    }
}
