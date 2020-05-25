using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageControl : MonoBehaviour
{
    public static GameStageControl Instance;
    public GameObject mainGround;
    public GameObject leftGround;
    public GameObject rightGround;

    public SpawnerTwo grassBiome;
    public SpawnerTwo factoryBiome;

    public Material grassMain;
    public Material grassBack;

    public Material factoryMain;
    public Material factoryBackL;
    public Material factoryBackR;

    public float left, middle, right;

    public float globalSpeed;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        ChangeSpeed(globalSpeed);


        grassBiome.gameOn = true;
        grassBiome.StartTheGame();

        

        //SwitchBiomeToFact();
    }

    public void turnGame(bool turnGameBool)
    {
        grassBiome.gameOn = turnGameBool;
        factoryBiome.gameOn = turnGameBool;
        
        if (turnGameBool)
        {
            mainGround.GetComponent<GroundShaper>().scrollSpeed = middle;
            leftGround.GetComponent<GroundShaper>().scrollSpeed = left;
            rightGround.GetComponent<GroundShaper>().scrollSpeed = right;
            grassBiome.StartTheGame();
            factoryBiome.StartTheGame();
        } else
        {
            mainGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            leftGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            rightGround.GetComponent<GroundShaper>().scrollSpeed = 0;
        }

    }

    public void ChangeSpeed(float curGlSp)
    {
        grassBiome.objSpeed = curGlSp;
        factoryBiome.objSpeed = curGlSp;
    }

    public IEnumerator SwitchBiomeToFact()
    {
        grassBiome.gameOn = false;
        PipeSpawn.Instance.SpawnThePipe();
        yield return new WaitForSeconds(3f);
        mainGround.GetComponent<MeshRenderer>().material = factoryMain;
        leftGround.GetComponent<MeshRenderer>().material = factoryBackL;
        rightGround.GetComponent<MeshRenderer>().material = factoryBackR;
        factoryBiome.gameOn = true;
        factoryBiome.StartTheGame();
    }

    public IEnumerator SwitchBiomeToForest()
    {
        factoryBiome.gameOn = false;
        PipeSpawn.Instance.SpawnThePipe();
        yield return new WaitForSeconds(3f);
        mainGround.GetComponent<MeshRenderer>().material = grassMain;
        leftGround.GetComponent<MeshRenderer>().material = grassBack;
        rightGround.GetComponent<MeshRenderer>().material = grassBack;
        grassBiome.gameOn = true;
        grassBiome.StartTheGame();
    }
}
