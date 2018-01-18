using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public GameObject enemySpawn;

    private PlayerMove isPlayerDead;

    public float speed;
    float speedIntervalIncrease;

    void Start()
    {
        isPlayerDead = GameObject.Find("Player").GetComponent<PlayerMove>();
        speed = 4.5f;
        
    }

    private void Update()
    {
        if(isPlayerDead.dead == true)
        {
            enemy.transform.position = enemySpawn.transform.position;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "player")
        {
            enemy.transform.Translate((player.transform.position - enemy.transform.position) * Time.deltaTime * speed);
        }
    }
}
