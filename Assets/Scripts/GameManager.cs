using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public GameObject Enemy;
    public bool isPlayerAlive;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerInstance = Instantiate(Player, new Vector2(-13, 0), Quaternion.identity);
        isPlayerAlive = true;
        playerInstance.GetComponent<Player>().livesText = livesText;

        scoreText.text = "x " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        killSwitch();
    }

    public void gameOver()
    {
        isPlayerAlive = false;
        Time.timeScale = 0;
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level_1");
        }

    }

    void killSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Application will (hopefully) close in a build");
        }
    }

    public void AddScore(int howMuch)
    {
        score = score + howMuch;
        scoreText.text = "x " + score;

    }


}
