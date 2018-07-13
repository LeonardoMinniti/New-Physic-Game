using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NewGameScript : MonoBehaviour {

    public Image GameOverImage;

    public void StartNewGame()
    {
        SceneManager.LoadScene("Scene01");
        GameOverImage.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameOverImage.gameObject.SetActive(false);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
