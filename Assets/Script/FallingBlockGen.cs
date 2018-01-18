using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingBlockGen : MonoBehaviour
{

    public GameObject spawn;
    public GameObject fallingBlockPreFab;

    public Slider difficulty;

    float xRange;
    float zRange = 400;

    int deathBlockSpawn;

    StartMenu isPlaying;

    private void Start()
    {
        isPlaying = GameObject.Find("Player").GetComponent<StartMenu>();
    }

    private void Update()
    {
        if (isPlaying.isPlayingYes == true)
        {
            print(isPlaying.isPlaying);
            blockGen();
            
        }
    }

    void blockGen()
    {
        for (int zPos = 1; zPos <= zRange; zPos++)
        {
            zPos -= -5;
            for (int x = 0; x <= difficulty.value * 5; x++)
            {
                xRange = Random.Range(-7.5f, 7.5f);
                GameObject.Instantiate(fallingBlockPreFab, new Vector3(xRange, 1100, zPos), fallingBlockPreFab.transform.rotation);
                GameObject.Instantiate(spawn, new Vector3(xRange, 1100, zPos), spawn.transform.rotation);
                if(x <= difficulty.value)
                {
                    isPlaying.isPlayingYes = false;
                }
            }
        }
    }

    
}
