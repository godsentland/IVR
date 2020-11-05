using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARPlayer : MonoBehaviour
{
    public Joystick joystick;
    float Speed = 2f;
    public float xMove;
    public float zMove;
    Rigidbody rb;
    public float timeLeft = 2f;

    bool flag = false;

    public Text text1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                text1.text = "";
                flag = false;
                timeLeft = 2f;
            }
            //timeLeft = 2f;
            //flag = false;
        }
    }

    void FixedUpdate()
    {
        xMove = joystick.Horizontal();
        zMove = joystick.Vertical();

        Vector3 MoveHor = transform.right * xMove;
        Vector3 MoveVer = transform.forward * zMove;

        Vector3 velocity = (MoveHor + MoveVer).normalized * Speed;

        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ARCyl1")
        {
            flag = true;
            text1.text = "Yellow goes first";
            //timeLeft -= Time.deltaTime;
            //if (timeLeft < 0)
            //{
            //    text1.text = "";
            //}
            //timeLeft = 2f;
        }
        if (other.gameObject.tag == "ARCyl2")
        {
            flag = true;
            text1.text = "After them goes green";
        }
        if (other.gameObject.tag == "ARCyl3")
        {
            flag = true;
            text1.text = "And then the red one";
        }
        if (other.gameObject.tag == "ARCyl4")
        {
            flag = true;
            text1.text = "Then goes blue";
        }
    }
}
