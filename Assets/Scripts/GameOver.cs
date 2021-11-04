using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryButton()
    { 
        SceneManager.LoadScene("IngameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}