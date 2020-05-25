using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageControl : MonoBehaviour
{
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

    private void Start()
    {
        //MeshRenderer meshRenderer = mainGround.GetComponent<MeshRenderer>();
        grassBiome.gameOn = true;
        grassBiome.StartTheGame();

        //SwitchBiomeToFact();
    }

    public void SwitchBiomeToFact()
    {
        grassBiome.gameOn = false;
        mainGround.GetComponent<MeshRenderer>().material = factoryMain;
        leftGround.GetComponent<MeshRenderer>().material = factoryBackL;
        rightGround.GetComponent<MeshRenderer>().material = factoryBackR;
        factoryBiome.gameOn = true;
        factoryBiome.StartTheGame();
        
    }
}
