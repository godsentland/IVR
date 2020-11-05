using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 TouchDistance;
    Vector2 PointerOld;
    int PointerID;
    public bool Pressed;

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            if (PointerID >= 0 && PointerID < Input.touches.Length)
            {
                TouchDistance = Input.touches[PointerID].position - PointerOld;
                PointerOld = Input.touches[PointerID].position;
            }
            else
            {
                TouchDistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDistance = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerID = eventData.pointerId;
        PointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
