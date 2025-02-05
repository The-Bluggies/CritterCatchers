using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button mainMenuButton;

    public GameObject MainMenu;
    public GameObject Credits;



    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(play);
        creditsButton.onClick.AddListener(credits);
        mainMenuButton.onClick.AddListener(mainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void play()
    {
        SceneManager.LoadScene("Level_1");
    }
    void credits()
    {
        MainMenu.gameObject.SetActive(false);
        Credits.gameObject.SetActive(true);

    }
    
    void mainMenu()
    {
        MainMenu.gameObject.SetActive(true);
        Credits.gameObject.SetActive(false);


    }

}
