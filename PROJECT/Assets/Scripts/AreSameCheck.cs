using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreSameCheck : MonoBehaviour
{
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    CubePuzzle cb1;
    CubePuzzle cb2;
    CubePuzzle cb3;
    CubePuzzle cb4;

    public UnityEvent SecondPuzzle = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        cb1 = Cube1.GetComponent<CubePuzzle>();
        cb2 = Cube2.GetComponent<CubePuzzle>();
        cb3 = Cube3.GetComponent<CubePuzzle>();
        cb4 = Cube4.GetComponent<CubePuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cb1.areSame == true && cb2.areSame == true && cb3.areSame == true && cb4.areSame == true)
        {
            SecondPuzzle.Invoke();
        }
    }
}
