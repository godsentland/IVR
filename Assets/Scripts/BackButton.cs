using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour
{

    Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
    }

    public void Back()
    {
        Debug.Log("BackButton pressed");
        SceneManager.LoadScene(CurrentScene.buildIndex - 1);
    }
}
