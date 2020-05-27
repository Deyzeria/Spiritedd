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

    public byte levelP = 1;

    public GameObject flasher;

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
    }

    public void AllAboardTheSkipIsStarting()
    {
        grassBiome.gameOn = true;
        grassBiome.StartTheGame();
    }

    public void turnGame(bool turnGameBool)
    {

        
        if (turnGameBool)
        {
            mainGround.GetComponent<GroundShaper>().scrollSpeed = middle;
            leftGround.GetComponent<GroundShaper>().scrollSpeed = left;
            rightGround.GetComponent<GroundShaper>().scrollSpeed = right;
            if(levelP == 1)
            {
                grassBiome.StartTheGame();
                grassBiome.gameOn = turnGameBool;
            } else
            {
                factoryBiome.StartTheGame();
                factoryBiome.gameOn = turnGameBool;
            }
        } else
        {
            mainGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            leftGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            rightGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            grassBiome.gameOn = turnGameBool;
            factoryBiome.gameOn = turnGameBool;
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

        yield return new WaitForSeconds(6f);
        flasher.GetComponent<Animator>().SetTrigger("Flash");
        Settings.Instance.ChangeMusicClip(2);
        yield return new WaitForSeconds(2f);

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

        yield return new WaitForSeconds(6f);
        flasher.GetComponent<Animator>().SetTrigger("Flash");
        Settings.Instance.ChangeMusicClip(1);
        yield return new WaitForSeconds(1.5f);

        mainGround.GetComponent<MeshRenderer>().material = grassMain;
        leftGround.GetComponent<MeshRenderer>().material = grassBack;
        rightGround.GetComponent<MeshRenderer>().material = grassBack;
        grassBiome.gameOn = true;
        grassBiome.StartTheGame();
    }
}
