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



    // Start is called before the first frame update
    void Start()
    {
        GameObject playerInstance = Instantiate(Player, new Vector2(-13, 0), Quaternion.identity);
        isPlayerAlive = true;



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


    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
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




}
