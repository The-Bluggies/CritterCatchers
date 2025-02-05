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
    public AudioClip winSound;
    AudioSource audioSource;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI goalText;
   // public TextMeshProUGUI goalText2;
    public TextMeshProUGUI passedText;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        goalText.gameObject.SetActive(true);
        passedText.gameObject.SetActive(false);
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

        if(score == 20 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_1"))
        {
            Time.timeScale = 0;
            passedText.gameObject.SetActive(true);
            audioSource.PlayOneShot(winSound);
            Camera.main.GetComponent<AudioSource>().Stop();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Level_2");
                Time.timeScale = 1;
                score = 0;
            }

        }
        if(score == 40 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_2"))
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<AudioSource>().Stop();
            audioSource.PlayOneShot(winSound);
            winText.gameObject.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                score = 0;
                SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1;
            }
        }

        
    }

    public void gameOver()
    {
        loseText.gameObject.SetActive(true);
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
