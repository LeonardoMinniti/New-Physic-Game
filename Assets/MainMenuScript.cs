using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public void StartNewGame()
    {
        SceneManager.LoadScene("Scene01");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }


}
