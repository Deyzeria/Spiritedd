using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTwo : MonoBehaviour
{
    public List<GameObject> oneBlockObject; //A single block. Can spawn in several places
    public List<GameObject> fullLaneObject; //Object, blocking the whole lane
    public List<GameObject> longLaneObject; //A singular object, that can block the lane for a long time
    public List<GameObject> specialObject;  //A special object
    public float resetSpeed = 0.2f;
    public float objSpeed;

    float curResetSpeed;
    int randomNum;
    public bool gameOn = false;
    bool mustReset;

    public List<GameObject> targets;

    int longLanePos, rememberNum, spawnsleft;
    bool forceSpawn = false;

    public void StartTheGame()
    {
        curResetSpeed = 3f;
        mustReset = true;
        StartCoroutine("SpawnerRoutine");
    }

    IEnumerator SpawnerRoutine()
    {
        while (gameOn)
        {
            if (mustReset)
            {
                yield return new WaitForSeconds(curResetSpeed);
                if (spawnsleft > 0)
                {
                    spawnsleft--;
                    randomNum = 2;
                    forceSpawn = true;
                }
                else
                {
                    randomNum = Random.Range(1, 8);
                    forceSpawn = false;
                    rememberNum = -1;
                }
                mustReset = false;
            }


            // 1- nothing for resetSpeed, 2,3,4 one block, 5 full lane, 6 long lane object, then rolling singular objects, 7 special object.
            switch (randomNum)
            {
                case 1:
                    
                    break;

                case 2:
                    int pos2_1 = Random.Range(0, 3);
                    if (forceSpawn && pos2_1 == longLanePos)
                    {
                        while (pos2_1 == longLanePos)
                        {
                            pos2_1 = Random.Range(0, 3);
                        }
                    }
                    ObjectSpawn(pos2_1, "oneblock");
                    break;

                case 3:
                    int pos3_1 = Random.Range(0, 3);
                    int pos3_2 = Random.Range(0, 3);
                    while (pos3_2 == pos3_1)
                    {
                        pos3_2 = Random.Range(0, 3);
                    }
                    ObjectSpawn(pos3_1, "oneblock");
                    ObjectSpawn(pos3_2, "oneblock");
                    break;

                case 4:
                    ObjectSpawn(0, "oneblock");
                    ObjectSpawn(1, "oneblock");
                    ObjectSpawn(2, "oneblock");
                    break;

                case 5:
                    ObjectSpawn(1, "fulllane");
                    break;

                case 6:
                    int pos6_1 = Random.Range(0, 3);
                    longLanePos = pos6_1;
                    ObjectSpawn(pos6_1, "longlane");
                    break;

                case 7:
                    ObjectSpawn(1, "special");
                    break;

            }
            mustReset = true;
            curResetSpeed = resetSpeed;
        }
    }

    void ObjectSpawn(int place, string type)
    {
        switch (type)
        {
            case "oneblock":
                GameObject spawnedOne = Instantiate(oneBlockObject[Random.Range(0, oneBlockObject.Count)], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedOne.GetComponent<ObjectMovement>().speed = objSpeed;
                break;

            case "fulllane":
                GameObject spawnedFull = Instantiate(fullLaneObject[Random.Range(0, fullLaneObject.Count)], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedFull.GetComponent<ObjectMovement>().speed = objSpeed;
                break;

            case "longlane":
                if (rememberNum == -1)
                {
                    rememberNum = Random.Range(0, longLaneObject.Count);
                }
                GameObject spawnedLong = Instantiate(oneBlockObject[rememberNum], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedLong.GetComponent<ObjectMovement>().speed = objSpeed;
                break;

            case "special":
                GameObject spawnedSpecial = Instantiate(oneBlockObject[Random.Range(0, specialObject.Count)], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedSpecial.GetComponent<ObjectMovement>().speed = objSpeed;
                break;
        }
        
    }
}
