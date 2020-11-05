using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzle : MonoBehaviour
{
    public string Tag;
    public bool areSame = false;
    //YellowCol = GameObject.Find("YellowCol");
    //BlueCol = GameObject.Find("BlueCol");
    //GreenCol = GameObject.Find("GreenColCol");
    //RedCol = GameObject.Find("RedCol");
    // Start is called before the first frame update
    void Start()
    {
        Tag = Convert.ToString(gameObject.tag);
    }

    void Update()
    {
        if (transform.position.y < -4 || transform.position.x == -10.511)
        {
            Vector3 position;
            position.x = 0.89f;
            position.y = 3.57f;
            position.z = 61.86f;
            transform.position = position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == Tag)
        {
            areSame = true;
            Vector3 position;
            position.x = -15f;
            position.y = 3.57f;
            position.z = 58.67f;
            transform.position = position;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "yellowcube")
        {
            Vector3 position;
            position.x = 0.89f;
            position.y = 3.57f;
            position.z = 61.86f;
            transform.position = position;
        }
        else if (other.tag == "greencube")
        {
            Vector3 position;
            position.x = 0.89f;
            position.y = 3.57f;
            position.z = 61.86f;
            transform.position = position;
        }
        else if (other.tag == "bluecube")
        {
            Vector3 position;
            position.x = 0.89f;
            position.y = 3.57f;
            position.z = 61.86f;
            transform.position = position;
        }
        else if (other.tag == "redcube")
        {
            Vector3 position;
            position.x = 0.89f;
            position.y = 3.57f;
            position.z = 61.86f;
            transform.position = position;
        }
    }
}
