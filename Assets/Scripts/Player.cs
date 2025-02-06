using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float speed;
    public static int lives;
    public static int score;

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    public GameObject Bullet;
    public GameManager gameManager;

    public TextMeshProUGUI livesText;

    public AudioClip jarSound;
    public AudioClip damageSound;
    public AudioClip loseSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        speed = 12f;
        rb = GetComponent<Rigidbody2D>();
        lives = 3;
        score = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        UpdateLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection();
        Shooting();
    }

    private void FixedUpdate()
    {
        // This determines player movement by considering direction and speed
        rb.velocity = movementDirection * speed;
    }
    void PlayerDirection()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    //Function that allows the player to shoot jars when the Space Bar is pressed
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0)
        {
            Instantiate(Bullet, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            audioSource.PlayOneShot(jarSound);
        }
    }

    //Function that manages the player's lives and checks to see whether the player is still alive 
    public void loseALife()
    {
        audioSource.PlayOneShot(damageSound);
        lives--;
        UpdateLivesText();
        if (lives == 0)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
            Destroy(this.gameObject, loseSound.length);
            gameManager.gameOver();
        }
    }

    //Function the updates the UI Lives text
    void UpdateLivesText()
    {
        livesText.text = "x " + lives;
    }

}
