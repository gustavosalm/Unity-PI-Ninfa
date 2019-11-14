using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Debug.Log("vazou");
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
