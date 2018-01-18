using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Ai : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemySpawn;

    private PlayerMove isPlayerDead;

    public float speed;

    void Start()
    {
        isPlayerDead = GameObject.Find("Player").GetComponent<PlayerMove>();
        speed = 4.5f;

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "player")
        {
            enemy.transform.Translate((player.transform.position - enemy.transform.position) * Time.deltaTime * speed);
            enemy1.transform.Translate((player.transform.position - enemy1.transform.position) * Time.deltaTime * speed * 1.5f);
            enemy2.transform.Translate((player.transform.position - enemy2.transform.position) * Time.deltaTime * speed * 2);
        }
    }
}
