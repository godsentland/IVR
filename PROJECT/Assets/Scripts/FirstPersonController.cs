using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;


public class FirstPersonController : MonoBehaviour
{
    public UnityEvent OnKeyCollected = new UnityEvent();
    public UnityEvent OnZoneEntered = new UnityEvent();

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
    public GameObject Key1;
    public GameObject KillZone;

    public int TutComp;
    public int AR1Comp;
    public int AR2Comp;
    public int AR3Comp;
    public bool isSaved = false;
    public float timeLeft = 2f;

    public Text gameSavedText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentScene = SceneManager.GetActiveScene();

        AR1Comp = PlayerPrefs.GetInt("AR1Completed");
        if (AR1Comp == 1 && CurrentScene.buildIndex == 2)
        {
            Vector3 position;
            position.x = -0.21f;
            position.y = 1.66f;
            position.z = 60f;
            transform.position = position;
            PlayerPrefs.SetInt("AR1Completed", 0);
        }

        AR2Comp = PlayerPrefs.GetInt("AR2Completed");
        if (AR2Comp == 1 && CurrentScene.buildIndex == 4)
        {
            Vector3 position;
            position.x = -0.21f;
            position.y = 1.138275f;
            position.z = 55.5f;
            transform.position = position;
            PlayerPrefs.SetInt("AR2Completed", 0);
        }

        AR3Comp = PlayerPrefs.GetInt("AR3Completed");
        if (AR3Comp == 1 && CurrentScene.buildIndex == 6)
        {
            Vector3 position;
            position.x = 19.01f;
            position.y = 1.09f;
            position.z = 0f;
            transform.position = position;
            PlayerPrefs.SetInt("AR3Completed", 0);
        }
        isSaved = true;
        gameSavedText.text = "Game Saved";
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
        if (isSaved == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                gameSavedText.text = "";
                isSaved = false;
                //timeLeft = 2f;
            }
            //timeLeft = 2f;
            //flag = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyController key = other.GetComponent<KeyController>();
        if (key != null)
        {
            key1 = true;
            key.Vanish();
            Debug.Log("wow, a key!");
        }
        if (other.gameObject.tag == "doorzone")
        {
            if (key1 == true)
            {
                OnKeyCollected.Invoke();
                KillZone.SetActive(false);
            }
            
        }
        if (other.gameObject.tag == "doorzone1")
        {
            Debug.Log("door1");
        }
        if (other.gameObject.tag == "AR1")
        {
            //SaveLoadManager.SavePlayerAR(this);
            PlayerPrefs.SetInt("AR1Completed", 1);
            SceneManager.LoadScene("FirstAR");
        }
        if (other.gameObject.tag == "AR2")
        {
            //SaveLoadManager.SavePlayerAR(this);
            PlayerPrefs.SetInt("AR2Completed", 1);
            SceneManager.LoadScene("SecondAR");
        }
        if (other.gameObject.tag == "AR3")
        {
            //SaveLoadManager.SavePlayerAR(this);
            //PlayerPrefs.SetInt("AR3Completed", 1);
            SceneManager.LoadScene("ThirdAR");
        }
        if (other.gameObject.tag == "nextlevel")
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            SceneManager.LoadScene(CurrentScene.buildIndex - 1);
            //TutComp = 1;
            
        }
        if (other.gameObject.tag == "back to start")
        {
            Vector3 position;
            position.x = 0.02056074f;
            position.y = 1.35f;
            position.z = -0.5475783f;
            transform.position = position;
        }
        if (other.gameObject.tag == "yellow zone for a door")
        {
            OnZoneEntered.Invoke();
        }
        if (other.gameObject.tag == "Level1")
        {
            //using (StreamWriter CoinData = new StreamWriter(Application.persistentDataPath + "/currentLevel.txt", false, Encoding.Default))
            //{
            //    LevelData.WriteLine(1); // Запись номера активной сцены
            //    LevelData.Close();
            //}
            //Debug.Log("Level1");
            SceneManager.LoadScene("Level1");
        }
        if (other.gameObject.tag == "Level1Completed")
        {
            PlayerPrefs.SetInt("Level1Completed", 1);
            SceneManager.LoadScene("MainScene");
        }
        if (other.gameObject.tag == "Level2")
        {
            //using (StreamWriter CoinData = new StreamWriter(Application.persistentDataPath + "/currentLevel.txt", false, Encoding.Default))
            //{
            //    CoinData.WriteLine(2); // Запись номера активной сцены
            //    CoinData.Close();
            //}
            //Debug.Log("Level2");
            SceneManager.LoadScene("Level2");
        }
        if (other.gameObject.tag == "Level2Completed")
        {
            PlayerPrefs.SetInt("Level2Completed", 1);
            //PlayerPrefs.SetInt("TutorialCompleted", 1);
            //L1 = 1;
            SceneManager.LoadScene("MainScene");
        }
    }

    //public void Save()
    //{
    //    //    //if (!isPaused)
    //    //    //{
    //    //    //    PlayerPrefs.SetInt("TutorialCompleted", 1);
    //    //    //}
    //    //    //if (L1 == 1)
    //    //    //{
    //    //    //    PlayerPrefs.SetInt("Level1Completed", 1);
    //    //    //}
    //    Debug.Log("Game Saved");
    //    isSaved = true;
        
    //}


    //public void SavePlayer()
    //{
    //    SaveLoadManager.SavePlayer(this);
    //}

    //public void LoadPlayer()
    //{
    //    PlayerData data = SaveLoadManager.LoadPlayer();

    //    Vector3 position;
    //    position.x = data.position[0];
    //    position.y = data.position[1];
    //    position.z = data.position[2];
    //    transform.position = position;
    //    key1 = data.key1;
    //    if (key1 == false)
    //    {
    //        Key1.SetActive(true);
    //    }
    //    else Key1.SetActive(false);
    //}
}
