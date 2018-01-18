using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject DeathParticals;
    public GameObject startMenu;

    public Text jumps;
    public Text blinks;
    public Text scoreText;
    public StartMenu isplaying;

    private int jumpsNumber = 1;
    private int blinksNumber = 1;
    private int scoreNumber;

    private bool wait = false;
    private bool checkPoint = false;
    private bool isActive;
    public bool dead;
    private bool level2;

    AI aiGuy;

    void Start()
    {
        scoreText.text = ("Score " + 0);
        jumps.text = ("Super Jump Potion " + jumpsNumber);
        blinks.text = ("Super Blinks Potion " + blinksNumber);

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (jumpsNumber > 0)
            {
                transform.Translate(0, Mathf.Lerp(0, 100, 0.1f), 0);
                jumpsNumber -= 1;
                jumps.text = ("Super Jump Potion " + jumpsNumber);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (blinksNumber > 0)
            {
                print("lol");
                transform.Translate(0, 0, 10);
                blinksNumber -= 1;
                blinks.text = ("Blink Jump Potion" + blinksNumber);
            }
        }
    }

    void FixedUpdate()
    {
        dead =false;
        if (level2 == false)
        {
            isplaying = GameObject.Find("Player").GetComponent<StartMenu>();

            if (isplaying.isPlaying == true)
            {
                startMenu.SetActive(false);
                isActive = true;
            }
        }
        if (isActive == true)
        {
            scoreNumber += 1;
            scoreText.text = ("Score " + scoreNumber);
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
            transform.Translate(x, 0, 0);
            if (wait == false)
            {
                transform.Translate(Input.acceleration.x, 0, 0);
                transform.Translate(0, 0, Time.deltaTime * 15f);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "enemy")
        {
            if (level2 == true)
            {
                Instantiate(DeathParticals, transform.position, Quaternion.identity);
                transform.position = new Vector3(0, 1026.1f, -48);
                scoreNumber -= 250;
                scoreText.text = ("Score " + scoreNumber);
                StartCoroutine("WaitFor2Seconds");
                dead = true;
            } else if (level2 == false)
            {
                Instantiate(DeathParticals, transform.position, Quaternion.identity);
                transform.position = new Vector3(0, 2, -48);
                scoreNumber -= 250;
                scoreText.text = ("Score " + scoreNumber);
                StartCoroutine("WaitFor2Seconds");
                dead = true;
            }
        }


        if (other.collider.tag == "Check Point 1")
        {
            transform.position = new Vector3(0, 2, 42);
            scoreNumber += 100;
            scoreText.text = ("Score " + scoreNumber);
            checkPoint = true;
        }

        if (other.collider.tag == "NextLevel")
        {
            transform.position = new Vector3(0, 1026.1f, -48);
            scoreNumber += 250;
            scoreText.text = ("Score " + scoreNumber);
            WaitFor2Seconds();
            level2 = true;
        }
           if(other.collider.tag == "JumpCol")
        {
            jumpsNumber += 2;
            jumps.text = ("Super Jump Potion " + jumpsNumber);
            scoreNumber += 1000;
            scoreText.text = ("Score " + scoreNumber);
        }

        if (other.collider.tag == "BlinkCol")
        {
            blinksNumber += 2;
            blinks.text = ("Super Blink Potion " + blinksNumber);
            scoreNumber += 1000;
            scoreText.text = ("Score " + scoreNumber);
        }
    }

    IEnumerator WaitFor2Seconds()
    {
        dead = false;
        wait = true;
        yield return new WaitForSeconds(1);
        wait = false;
    }
}
