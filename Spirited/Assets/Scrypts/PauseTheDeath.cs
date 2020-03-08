using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseTheDeath : MonoBehaviour
{
    public static PauseTheDeath Instance;
    public Image DeadImage;
    public GameObject Menu;
    public GameObject DeathMenu;
    public GameObject PauseButton;
    public GameObject settingsMenu;
    bool settingsOn = false;
    public float musicAVolume = 1;
    public float soundAVolume = 1;
    public Slider musicASlider;
    public Slider soundASlider;

    public Text DeathText, DeathTextBack;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Menu.SetActive(false);
        DeathMenu.SetActive(false);

        if (Settings.Instance != null)
        {
            musicAVolume = Settings.Instance.musicVolume;
            soundAVolume = Settings.Instance.soundVolume;

            musicASlider.GetComponent<Slider>().value = musicAVolume;
            soundASlider.GetComponent<Slider>().value = soundAVolume;
        }
    }

    public void FindAllAndFreeze()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject Blockk in objs)
        {
            Blockk.GetComponent<Block>().speed = 0;
        }
        PauseButton.SetActive(false);
        DeadImage.GetComponent<Animator>().SetTrigger("Dead");

        DeathMenu.SetActive(true);
        DeathText.GetComponent<Text>().text = Spawn.Instance.Score.ToString();
        DeathTextBack.GetComponent<Text>().text = Spawn.Instance.Score.ToString();

    }

    public void ChangeMusic()
    {
        musicAVolume = musicASlider.GetComponent<Slider>().value;
        Settings.Instance.GetComponent<AudioSource>().volume = musicAVolume;
    }

    public void ChangeSound()
    {
        soundAVolume = soundASlider.GetComponent<Slider>().value;
    }

    private IEnumerator SwitchToLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    public void SettingsMenu()
    {
        if (settingsOn == false)
        {
            settingsMenu.SetActive(true);
            Menu.SetActive(false);
            settingsOn = true;
        }
        else
        {
            settingsMenu.SetActive(false);
            Menu.SetActive(true);
            settingsOn = false;
        }
    }

    public void StartGame()
    {
        Debug.Log("A");
        DeadImage.GetComponent<Animator>().SetTrigger("NewGamePlus");
        DeathMenu.SetActive(false);
        StartCoroutine(SwitchToLevel());
    }

    public void StopWaitAMinute()
    {
        Settings.Instance.Jump.enabled = false;
        Settings.Instance.Sound.enabled = false;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject Blockk in objs)
        {
            Blockk.GetComponent<Block>().speed = 0;
        }
        PauseButton.SetActive(false);
        DeadImage.GetComponent<Animator>().SetTrigger("Paused");
        DeadImage.GetComponent<Animator>().SetBool("Paus", true);
        Movement.Instance.pauseAnim(0);
        Menu.SetActive(true);
    }

    public void resumeDatShit()
    {
        Settings.Instance.Jump.enabled = true;
        Settings.Instance.Sound.enabled = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject Blockk in objs)
        {
            Blockk.GetComponent<Block>().speed = Spawn.Instance.worldSpeed;
        }
        PauseButton.SetActive(true);
        DeadImage.GetComponent<Animator>().ResetTrigger("Paused");
        DeadImage.GetComponent<Animator>().SetBool("Paus", false);
        Movement.Instance.pauseAnim(1);
        Menu.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
