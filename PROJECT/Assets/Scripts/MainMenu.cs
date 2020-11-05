using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MainMenu : MonoBehaviour
{
    public int tut = 0;
    // Start is called before the first frame update
    void Start()
    {
        tut = PlayerPrefs.GetInt("TutorialCompleted");
    }

    public void PlayGame()
    {
        if (tut == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
