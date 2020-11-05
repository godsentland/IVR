using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WhiteBlueRedCheck : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    ColorChanger mr1;
    ColorChanger mr2;
    ColorChanger mr3;
    public Material white;
    public Material blue;
    public Material red;

    public UnityEvent FirstPuzzle = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        mr1 = c1.GetComponent<ColorChanger>();
        mr2 = c2.GetComponent<ColorChanger>();
        mr3 = c3.GetComponent<ColorChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mr1.a && mr2.b && mr3.c)
        {
            FirstPuzzle.Invoke();
        }
    }
}
