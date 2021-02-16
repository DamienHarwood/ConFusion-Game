using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        //unused so far, not sure if Ill implement this or not.
    }

    public void QuitGame()
    {
        //doesnt work in editor, onlt works when the game is built
        Debug.Log("Game Has Quit");
        Application.Quit();
    }
}
