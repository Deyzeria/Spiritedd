using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public float musicVolume = 1;
    public float soundVolume = 1;
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource Music;
    public AudioSource Sound;
    public AudioSource Jump;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(this);
        }
        
        DontDestroyOnLoad(gameObject);
        Sound.enabled = false;
        Jump.enabled = false;
    }

    public void TurnOnSound()
    {
        Sound.enabled = true;
    }

    public void SoundJump()
    {
        Jump.Play(0);
    }

    public void ChangeMusic()
    {
        musicVolume = musicSlider.GetComponent<Slider>().value;
        Music.volume = musicVolume;
    }

    public void ChangeSound()
    {
        soundVolume = soundSlider.GetComponent<Slider>().value;
        Sound.volume = soundVolume;
        Jump.volume = soundVolume;
    }
}
