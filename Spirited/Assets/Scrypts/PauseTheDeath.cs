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

    public Text DeathText, DeathTextBack;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Menu.SetActive(false);
        DeathMenu.SetActive(false);
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

    private IEnumerator SwitchToLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
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
        Application.Quit();
    }
}
