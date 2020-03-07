using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject cube;
    private Animator anim;
    private void Start()
    {
        cube.SetActive(false);
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

}
