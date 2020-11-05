using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousLevelBut : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Spy pressed");
        PlayerPrefs.SetInt("AR3Completed", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
