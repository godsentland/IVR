using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class VBScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject VB;
    // Start is called before the first frame update
    void Start()
    {
        VB = GameObject.Find("VirtualButton");
        VB.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour VB)
    {
        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released");
        PlayerPrefs.SetInt("AR3Completed", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
