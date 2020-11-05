using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARKey : MonoBehaviour
{
    public float RotationRate = 1.0f;
    private Vector3 rotationAxis = new Vector3(0, 1, 0);
    public Text Task;

    private void FixedUpdate()
    {
        rotationAxis += Random.onUnitSphere / 50;
        transform.Rotate(rotationAxis, RotationRate);
    }

    void OnMouseDown()
    {
        Task.text = "russia is the best \n i really love russia \n russian flag is the most beautiful \n white<3 blue<3 red<3";
    }
}
