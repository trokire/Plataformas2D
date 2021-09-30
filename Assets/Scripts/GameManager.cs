using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;
    public GameObject gameOverBox;

    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseLive()
    {
        lives--;
        if (lives == 2)
        {
            heart3.SetActive(false);
        }
        if (lives == 1)
        {
            heart2.SetActive(false);
        }
        if (lives == 0)
        {
            heart1.SetActive(false);
            gameOverBox.SetActive(true);
        }

    }

}
