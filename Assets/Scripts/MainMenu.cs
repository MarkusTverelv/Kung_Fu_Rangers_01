using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGameButton()
    {
        SceneManager.LoadScene("IngameScene");
    }

   public void QuitButton()
    {
        Application.Quit();
    }
}