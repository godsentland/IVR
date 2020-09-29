using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    public Slider slider;

    

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("SliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("SliderValue");
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
        float SlVal = slider.value;
        PlayerPrefs.SetFloat("SliderValue", SlVal);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
