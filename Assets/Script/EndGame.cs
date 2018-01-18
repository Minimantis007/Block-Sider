using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject WinGame;
    public GameObject MainGame;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            WinGame.SetActive(true);
            MainGame.SetActive(false);
        }
    }

}
