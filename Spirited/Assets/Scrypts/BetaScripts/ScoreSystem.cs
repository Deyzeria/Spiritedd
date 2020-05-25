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

            if(finalscore == 15)
            {
                GameStageControl.Instance.SwitchBiomeToFact();
            }
        }
    }
}
