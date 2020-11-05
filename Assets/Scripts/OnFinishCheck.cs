using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnFinishCheck : MonoBehaviour
{
    public UnityEvent OnFinish = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCube")
        {
            OnFinish.Invoke();
        }
        else if (other.gameObject.tag == "SimpleCube")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
