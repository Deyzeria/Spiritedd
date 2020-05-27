﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTwo : MonoBehaviour
{
    public List<GameObject> oneBlockObject; //A single block. Can spawn in several places
    public List<GameObject> fullLaneObject; //Object, blocking the whole lane
    public List<GameObject> longLaneObject; //A singular object, that can block the lane for a long time
    public List<GameObject> specialObject;  //A special object
    public float resetSpeed = 0.05f;
    public float objSpeed;

    float curResetSpeed;
    int randomNum;
    public bool gameOn = false;
    bool mustReset;

    public List<GameObject> targets;

    int longLanePos, rememberNum, spawnsleft;
    bool forceSpawn = false;
    bool firstTime = true;

    GameObject spawnedObject;

    public void StartTheGame()
    {
        if (firstTime)
        {
            curResetSpeed = 3f;
            firstTime = false;
        }
        mustReset = true;
        StartCoroutine("SpawnerRoutine");
    }

    IEnumerator SpawnerRoutine()
    {
        while (true)
        {
            if (gameOn)
            {
                if (mustReset)
                {
                    yield return new WaitForSecondsRealtime(curResetSpeed);
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
                        int pos1_1 = Random.Range(0, 3);
                        if (forceSpawn && pos1_1 == longLanePos)
                        {
                            while (pos1_1 == longLanePos)
                            {
                                pos1_1 = Random.Range(0, 3);
                            }
                        }
                        ObjectSpawn(pos1_1, "oneblock", false);
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
                        ObjectSpawn(pos2_1, "oneblock", false);
                        break;

                    case 3:
                        int pos3_1 = Random.Range(0, 3);
                        int pos3_2 = Random.Range(0, 3);
                        while (pos3_2 == pos3_1)
                        {
                            pos3_2 = Random.Range(0, 3);
                        }
                        ObjectSpawn(pos3_1, "oneblock", false);
                        ObjectSpawn(pos3_2, "oneblock", false);
                        break;

                    case 4:
                        ObjectSpawn(0, "oneblock", false);
                        ObjectSpawn(1, "oneblock", true);
                        ObjectSpawn(2, "oneblock", false);
                        break;

                    case 5:
                        ObjectSpawn(1, "fulllane", false);
                        break;

                    case 6:
                        int pos6_1 = Random.Range(0, 3);
                        longLanePos = pos6_1;
                        ObjectSpawn(pos6_1, "longlane", false);
                        break;

                    case 7:
                        ObjectSpawn(1, "special", false);
                        break;

                }
                mustReset = true;
                curResetSpeed = resetSpeed;
            } else
            {
                Debug.Log("Before Crash");
                Debug.Log("Crash");
                StopCoroutine("SpawnerRoutine");
                yield return new WaitForSeconds(3);
            }
        }
    }

    void ObjectSpawn(int place, string type, bool forced)
    {
        switch (type)
        {
            case "oneblock":
                if (!forced)
                {
                    spawnedObject = Instantiate(oneBlockObject[Random.Range(0, oneBlockObject.Count)], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                } else
                {
                    spawnedObject = Instantiate(oneBlockObject[0], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);

                }
                spawnedObject.GetComponent<ObjectMovement>().speed = objSpeed;
                break;

            case "fulllane":
                spawnedObject = Instantiate(fullLaneObject[Random.Range(0, fullLaneObject.Count)], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedObject.GetComponent<ObjectMovement>().speed = objSpeed;
                break;

            case "longlane":
                if (rememberNum == -1)
                {
                    rememberNum = Random.Range(0, longLaneObject.Count);
                }
                spawnedObject = Instantiate(oneBlockObject[rememberNum], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedObject.GetComponent<ObjectMovement>().speed = objSpeed;
                break;

            case "special":
                spawnedObject = Instantiate(oneBlockObject[Random.Range(0, specialObject.Count)], new Vector3(targets[place].transform.position.x, targets[place].transform.position.y, targets[place].transform.position.z), Quaternion.identity);
                spawnedObject.GetComponent<ObjectMovement>().speed = objSpeed;
                break;
        }
        
    }
}
