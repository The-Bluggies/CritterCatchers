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
        
    }

    public void gameOver()
    {
        isPlayerAlive = false;



    }



}
