using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text texter;
    long finalscore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("scorSystem");
    }

    IEnumerator scorSystem()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            finalscore++;
            texter.GetComponent<Text>().text = finalscore.ToString();
        }
    }
}
