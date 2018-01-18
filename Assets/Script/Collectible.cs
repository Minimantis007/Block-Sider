using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour {

    public Text jumpNumberText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
