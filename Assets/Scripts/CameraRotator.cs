using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public TouchField touchField;
    public float minX = -90;
    public float maxX = 90;

    Quaternion StartRot;
    float xRot;

    // Start is called before the first frame update
    void Start()
    {
        StartRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        xRot += touchField.TouchDistance.y / 20;
        xRot = xRot % 360;
        xRot = Mathf.Clamp(xRot, minX, maxX); //ограничиваем xRot
        Quaternion yQuaternion = Quaternion.AngleAxis(xRot, Vector3.left);
        transform.localRotation = StartRot * yQuaternion;
    }
}
