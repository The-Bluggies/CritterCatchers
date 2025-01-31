using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button playButton;





    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void play()
    {
        SceneManager.LoadScene("Level_1");



    }

}
