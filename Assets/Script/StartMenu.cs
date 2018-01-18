using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public bool isPlaying = false;
    public bool isPlayingYes = false;
    public bool instructions = false;

    public GameObject player;
    public GameObject play;
    public GameObject inventory;

    

        public void OnPlayPress ()
    {
        isPlaying = true;
        isPlayingYes = true;
        player.transform.position = new Vector3 (0, 2, -48);
    }

    public void OnInstructionPress()
    {
        instructions = !instructions;
        if (instructions == true)
        {
            play.SetActive(false);
            inventory.SetActive(true);
        } else if (instructions == false)
        { 
            inventory.SetActive(false);
            play.SetActive(true);
        }
    }

    public void OnExitPress()
    {
        print("Test");
        Application.Quit();
    }
}

