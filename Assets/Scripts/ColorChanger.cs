using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    MeshRenderer mr;
    public Material white;
    public Material blue;
    public Material red;
    int mym = 0;
    int[] mats = new int[3] { 1, 2, 3 };
    public bool a = false;
    public bool b = false;
    public bool c = false;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mym == 1)
        {
            mr.material = white;
            a = true;
            b = false;
            c = false;
        }
        if (mym == 2)
        {
            mr.material = blue;
            a = false;
            b = true;
            c = false;
        }
        if (mym == 3)
        {
            mr.material = red;
            a = false;
            b = false;
            c = true;
        }
    }
    void OnMouseDown()
    {
        mym = mats[new System.Random().Next(0, mats.Length)];
    }
}