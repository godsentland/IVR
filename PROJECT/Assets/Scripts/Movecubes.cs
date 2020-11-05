using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.SceneManagement;

public class Movecubes : MonoBehaviour
{
    public GameObject Cube1;
    public GameObject Cube2;
    public Vector3 moveDir;

    void OnMouseDown()
    {
        Cube1.GetComponent<Rigidbody>().velocity += moveDir;
        Cube2.GetComponent<Rigidbody>().velocity += moveDir;
    }
}
