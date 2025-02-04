using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float speed;

    private int shooting;
    public int lives;

    public int score;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    public GameObject Bullet;
    public GameManager gameManager;

<<<<<<< HEAD
=======
   /* public GameObject Healthtext;
    public GameObject Scoretext;
    public GameObject Gametext;

    TextMeshProUGUI Healthtext_text;
    TextMeshProUGUI Scoretext_text;
    TextMeshProUGUI Gametext_text;*/
>>>>>>> e54ee6d78509c181a4dd662f7326170bf137de47

    public AudioClip jarSound;
    public AudioClip damageSound;
    public AudioClip loseSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       /* Healthtext_text = Healthtext.GetComponent<TextMeshProUGUI>();
        Scoretext_text = Scoretext.GetComponent<TextMeshProUGUI>();
        Gametext_text = Gametext.GetComponent<TextMeshProUGUI>(); */
        audioSource = GetComponent<AudioSource>();
        speed = 12f;
        rb = GetComponent<Rigidbody2D>();
        shooting = 1;
        lives = 3;
        score = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
       // Scoretext_text.text = "Score: " + score.ToString();
        PlayerDirection();
        Shooting();
    }

    private void FixedUpdate()
    {
        // This determines player movement by considering direction and speed
        // KEEP THIS HERE BECAUSE Rigidbody2D will get scuffed in normal Update since it uses Unity's physics system
        rb.velocity = movementDirection * speed;


    }

    void PlayerDirection()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (shooting)
            {
                //FOR ALL SHOOTING CASES, we use Vector3 instead of Vector2 to modify direction because the code just doesn't like it for some reason.
                // if we don't ever add any shooting modes we can just delete the switch case section of this code.
                case 1:
                    //Normal Shot
                        Instantiate(Bullet, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                        audioSource.PlayOneShot(jarSound);
                    break;

            }

        }
    }
    public void loseALife()
    {
        audioSource.PlayOneShot(damageSound);
        lives--;

        if (lives == 0)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
           /* Gametext.SetActive(true);
            Gametext_text.text = "Game Over! Press R to Restart!"; */
            Destroy(this.gameObject);
            gameManager.gameOver();
        }
    }

    public void finalScore()
    {
        score+=1;
    }
}
