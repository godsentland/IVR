using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GimmeTheKey : MonoBehaviour
{
    public UnityEvent OnKeyCollected = new UnityEvent();

    void OnMouseDown()
    {
        OnKeyCollected.Invoke();
    }
}
