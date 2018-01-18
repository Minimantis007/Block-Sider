using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingBlocks : MonoBehaviour {

    public GameObject spawn;

    private Vector3 spawnPos;

    public ParticleSystem deathParticles;

    public float speed;

    private void Start()
    {
        spawnPos = transform.position;
        speed = Random.Range(-0.1f, -0.5f);
    }

    private void Update()
    {
        transform.Translate(0, speed, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Vector3 curPos = transform.position;
            spawnPos = new Vector3(this.transform.position.x + Random.Range(-6.5f, 6.5f), this.transform.position.y + 100, this.transform.position.z + Random.Range(-20, 20));
            Instantiate(deathParticles, curPos, Quaternion.identity).Play();
            transform.position = spawnPos;
        }
        else if (collision.collider.tag == "enemy")
        {
            spawnPos = new Vector3(this.transform.position.x + Random.Range(-6.5f, 6.5f), this.transform.position.y + 100, this.transform.position.z + Random.Range(-20, 20));
            transform.position = spawnPos;
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
