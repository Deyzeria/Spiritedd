using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    public Text texter;
    public Light lightObj;
    [HideInInspector]
    public long finalscore;
    public float intensityMod;
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
        StartCoroutine("scorSystem");
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
            if (intensityMod < 60) {
                intensityMod++;
                lightObj.intensity = intensityMod / 10;
            }

            if (finalscore == 25 || finalscore == 125 || finalscore == 200)
            {
                level = 2;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.StartCoroutine("SwitchBiomeToFact");
            }

            if (finalscore == 75 || finalscore == 175 || finalscore == 200)
            {
                level = 1;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.StartCoroutine("SwitchBiomeToForest");

            }

        }
    }
}
