using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float Step = 0.3f;
    //public float UpperLevel = 10;

    public void OpenDoor(float UpperLevel)
    {
        StartCoroutine(openAnimation(UpperLevel));
    }

    IEnumerator openAnimation(float UpperLevel)
    {

        while (transform.position.y < UpperLevel)
        {
            transform.position += new Vector3(0, Step, 0);
            yield return new WaitForSeconds(1);
        }
    }
}
