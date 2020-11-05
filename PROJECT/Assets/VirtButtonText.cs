using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtButtonText : MonoBehaviour
{
    public Text text1;
    public float timeLeft = 10f;
    //bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                text1.text = "the button is real \n i promise!";
            }
    }

    //void OnMouseDown()
    //{
    //    Debug.Log("Stupid!");
    //    flag = true;
    //    text1.text = "didn't think you are so stupid \n the button is real! i promise!";
    //}
}
