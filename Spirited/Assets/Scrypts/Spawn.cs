using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject basicElement;
    public List<GameObject> possibleElements;
    public GameObject lastElement;
    [Space]
    public int worldSpeed = 10;
    [Space]
    int spaceInBetween = 4;
    public int curSpace = 20;
    int curHoleSpace;
    int randNum;
    string bigKop;
    public GameObject scoreText;
    public GameObject PButton;
    public int Score = -20;

    public static Spawn Instance;



    private void Start()
    {
        Instance = this;
        StartCoroutine(Appear());
    }

    private IEnumerator Appear()
    {
        yield return new WaitForSeconds(3f);
        scoreText.SetActive(true);
        PButton.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            spawnBlock();
            Score++;
            scoreText.GetComponent<Text>().text = Score.ToString();
        }
    }
    
    public void RipInPieces()
    {
        scoreText.SetActive(false);
    }

    public void spawnBlock()
    {
        if (curHoleSpace > 0)
        {
            GameObject box = Instantiate(possibleElements[randNum], new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
            box.GetComponent<Block>().speed = worldSpeed;
            lastElement = box;
            curHoleSpace--;
        }
        else
        if (curSpace > 0)
        {
            GameObject box = Instantiate(basicElement, new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
            box.GetComponent<Block>().speed = worldSpeed;

            lastElement = box;
            curSpace--;
        }
        else
        {
            randNum = Random.Range(0, possibleElements.Count);
            GameObject box = Instantiate(possibleElements[randNum], new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
            bigKop = box.GetComponent<Block>().onLeft.ToString() + box.GetComponent<Block>().onMid.ToString() + box.GetComponent<Block>().onRight.ToString();
            box.GetComponent<Block>().speed = worldSpeed;
            lastElement = box;

            if (bigKop == "000" || bigKop == "222")
            {
                curSpace = Random.Range(1, 3);
            }
            else if (bigKop == "112" || bigKop == "211" || bigKop == "121")
            {
                curSpace = Random.Range(0, 3);
            }
            else if (bigKop == "113" || bigKop == "311" || bigKop == "131")
            {
                curSpace = Random.Range(0, 2);
            }
            else if (bigKop == "001" || bigKop == "010" || bigKop == "011" || bigKop == "100" || bigKop == "101" || bigKop == "110")
            {
                curHoleSpace = Random.Range(1, 4);
                curSpace = spaceInBetween - 2;
            }
            /*
            for (int i = 5; i < 12; i++)
            {
                if (bigKop == possibleElements[i].GetComponent<Block>().bKop)
                {
                    Debug.Log("AA");
                    curHoleSpace = Random.Range(1, 8);
                }
            }*/
        }
    }
}

