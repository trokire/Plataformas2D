using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            gameManager.GetComponent<SoundManager>().PlayBombFX();
            gameManager.GetComponent<GameManager>().LoseLive();
        }
    }

}
