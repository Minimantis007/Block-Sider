using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

    public GameObject player;
    public GameObject winButton;
    public GameObject MainMenu;
    public GameObject MainGame;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnMainMenuPress ()
    {

        player.transform.position = new Vector3 (0, 2, -48);
        winButton.SetActive(false);
        MainMenu.SetActive(true);
        MainGame.SetActive(true);
    }
}
