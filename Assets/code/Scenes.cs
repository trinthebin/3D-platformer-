using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayScreen()
    {
        SceneManager.LoadScene("3D platformer");
    }

    public void OptionScreen()
    {
        SceneManager.LoadScene("Option");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
