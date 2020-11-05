using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelDoorsManager : MonoBehaviour
{
    public UnityEvent L1Open = new UnityEvent();
    public UnityEvent L2Open = new UnityEvent();

    public int TutComp;
    public int L1Comp;
    // Start is called before the first frame update
    void Start()
    {
        TutComp = PlayerPrefs.GetInt("TutorialCompleted");
        L1Comp = PlayerPrefs.GetInt("Level1Completed");
        if (TutComp == 1)
        {
            L1Open.Invoke();
        }
        if (L1Comp == 1)
        {
            L2Open.Invoke();
        }
    }
}
