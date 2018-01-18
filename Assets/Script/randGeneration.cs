using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randGeneration : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject DeathBlock;
    public GameObject Jump;
    public GameObject Blink;

    int difficulty;
    int deathBlockSpawn;
    int blocksSpawn;
    float xRange;
    float zRange = 100;

	void Start ()
    {
        deathBlockSpawn = 1;
        difficulty = 100;
        blocksSpawn = 5;
        blockGen();
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }



    void blockGen()
    {
        for (int zPos = 1; zPos <= zRange; zPos++)
        {
            zPos -= -5;
            for (int x = 1; x <= blocksSpawn; x++)
            {
                xRange = Random.Range(-7.5f, 7.5f);
                GameObject.Instantiate(Obstacle, new Vector3(xRange,2,zPos), Obstacle.transform.rotation);
            }
        }

        for (int zPos = 1; zPos <= difficulty; zPos++)
        {
            zPos -= -7;
            for (int x = 1; x <= deathBlockSpawn; x++)
            {
                xRange = Random.Range(-7.5f, 7.5f);
                GameObject.Instantiate(DeathBlock, new Vector3(xRange, 2, zPos), DeathBlock.transform.rotation);
            }
        }
        for (float zPos = 0; zPos <= 400; zPos++)
        {
            zPos -= -5.5f;
            for (int x = 1; x <= blocksSpawn; x++)
            {
                xRange = Random.Range(-7f, 7f);
                GameObject.Instantiate(Obstacle, new Vector3(xRange, 1026.1f, zPos), Obstacle.transform.rotation);
            }
        }

        for (int zPos = 0; zPos <= 400; zPos++)
        {
            zPos -= -7;
            for (int x = 1; x <= deathBlockSpawn; x++)
            {
                xRange = Random.Range(-7f, 7f);
                GameObject.Instantiate(DeathBlock, new Vector3(xRange, 1026.1f, zPos), DeathBlock.transform.rotation);
            }
        }

        for (int colzPos = 0; colzPos <= 80; colzPos++)
        {
            colzPos += 20;
            xRange = Random.Range(-7, 7);
            GameObject.Instantiate(Jump, new Vector3(xRange, 1026.1f, colzPos + 30), Jump.transform.rotation);
        }

        for (int colzPos = 0; colzPos <= 40; colzPos++)
        {
            colzPos += 10;
            xRange = Random.Range(-7, 7);
            GameObject.Instantiate(Blink, new Vector3(xRange, 1026.1f, colzPos + 40), Blink.transform.rotation);
        }

    }
}
