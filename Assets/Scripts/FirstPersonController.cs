using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public UnityEvent OnKeyCollected = new UnityEvent();

    public TouchField touchField;
    public Joystick joystick;
    float Speed = 5f;
    public float xMove;
    public float zMove;

    public bool key1 = false;

    float xRot; 
    //float yRot;
    Rigidbody rb;
    public bool Ground = false;

    Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        xMove = joystick.Horizontal();
        zMove = joystick.Vertical();

        xRot = touchField.TouchDistance.x / 20; 
        /*yRot = touchField.TouchDistance.y / 20;*/ //делим на 20, чтобы чувствительность не была слишком высокой 

        //xMove = Input.GetAxis("Horizontal");
        //zMove = Input.GetAxis("Vertical");

        //xRot = Input.GetAxis("Mouse X");
        //yRot = Input.GetAxis("Mouse Y");

        Vector3 MoveHor = transform.right * xMove;
        Vector3 MoveVer = transform.forward * zMove;

        Vector3 velocity = (MoveHor + MoveVer).normalized * Speed;
        Vector3 Rotation = new Vector3(0, xRot, 0) * Speed; 
        //Vector3 camRotation = new Vector3(yRot, 0, 0) * Speed; 

        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Rotation)); 

        //Camera.main.transform.Rotate(-camRotation); в другом скрипте
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyController key = other.GetComponent<KeyController>();
        if (key != null)
        {
            key1 = true;
            key.Vanish();
            Debug.Log("wow, a key!");

            //rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            ////rb.constraints = RigidbodyConstraints.FreezeRotationZ && RigidbodyConstraints.FreezeRotationX;
        }
        if (other.gameObject.tag == "doorzone")
        {
            if (key1 == true)
            {
                OnKeyCollected.Invoke();
            }
            
        }
        if (other.gameObject.tag == "nextlevel")
        {
            SceneManager.LoadScene("FirstAR");

        }
    }
}
