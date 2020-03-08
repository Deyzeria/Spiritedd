using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject cube;
    private Animator anim;
    public GameObject settingsMenu;
    public GameObject settingsButton;
    bool settingsOn = false;
    private void Start()
    {
        cube.SetActive(false);
        settingsMenu.SetActive(false);
        anim = cube.GetComponent<Animator>();
    }
    private IEnumerator SwitchToLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        Debug.Log("A");
        cube.SetActive(true);
        anim.SetBool("Fill", true);
        StartCoroutine(SwitchToLevel());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        if (settingsOn == false)
        {
            settingsMenu.SetActive(true);
            settingsButton.SetActive(false);
            settingsOn = true;
        } else
        {
            settingsMenu.SetActive(false);
            settingsButton.SetActive(true);
            settingsOn = false;
        }
    }

}
