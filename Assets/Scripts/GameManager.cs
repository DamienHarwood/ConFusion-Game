using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coinsCollected = 0;

    public GameObject Player;

    public GameObject Camera;

    public GameObject EndLevelPlatform;

    // instance
    public static GameManager instance;

    //NOT IN SCENE YET. STILL HAVING ISSUES WITH INSTANTIATING PLAYER AND CAMERA CORRECTLY

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Instantiate(Player);

        Instantiate(Camera);
    }


    public void LevelEnd()
    {
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            WinGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void WinGame()
    {
    }

    public void GameOver()
    {
    }
}