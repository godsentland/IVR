using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    Image JoystickBG;
    Image joystick;
    Vector2 InputVector;

    void Start()
    {
        JoystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 Position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBG.rectTransform, eventData.position, eventData.pressEventCamera, out Position)) // сравниваем место, в которое "пришел" палец с позицией JoystickBG и  с вектором Position
        {
            Position.x = (Position.x / JoystickBG.rectTransform.sizeDelta.x + 0.5f);
            Position.y = (Position.y / JoystickBG.rectTransform.sizeDelta.y + 0.5f); // изменяем позицию вектора
        }
        InputVector = new Vector2(Position.x * 2 - 1, Position.y * 2 - 1);
        InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector; // если длина вектора становится больше 1, то длина становится равна единице, если нет - все окей

        joystick.rectTransform.anchoredPosition = new Vector2(InputVector.x * (JoystickBG.rectTransform.sizeDelta.x / 2), InputVector.y * (JoystickBG.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (InputVector.x != 0)
        {
            return InputVector.x;
        }
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (InputVector.y != 0)
        {
            return InputVector.y;
        }
        else return Input.GetAxis("Vertical");
    }
}
