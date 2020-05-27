using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    public Text texter;
    [HideInInspector]
    public long finalscore;
    byte level = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void startcor()
    {
        StartCoroutine("scorSystem");
    }

    public void stopCor()
    {
        StopCoroutine("scorSystem");
    }

    IEnumerator scorSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            finalscore++;
            texter.GetComponent<Text>().text = finalscore.ToString();

            if (finalscore == 50 || finalscore == 200 || finalscore == 400)
            {
                level = 2;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.StartCoroutine("SwitchBiomeToFact");
            }

            if (finalscore == 100 || finalscore == 300 || finalscore == 500)
            {
                level = 1;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.StartCoroutine("SwitchBiomeToForest");

            }

        }
    }
}
