using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private Vector3 startPosition;

    [SerializeField] private float moveSpeed = 6f;

    [SerializeField] private float frequency = 5f;

    [SerializeField] private float magnitude = 5f;

    [SerializeField] private float offset = 0f;

    public GameObject Player;
    public GameObject Bullet;
    public GameObject AcidAttack;

    public AudioClip collectSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        startPosition = transform.position;
        InvokeRepeating("RangedAttack", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        AntSine();
    }

    void AntSine()
    {
        if (transform.position.x >= 11)
        {
            startPosition -= transform.right * Time.deltaTime * moveSpeed;
            transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
        }
        
        else
        {
            transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
        }
    }

    void RangedAttack()
    {
        Instantiate(AcidAttack,transform.position, Quaternion.identity);
    }

    //Function that checks to see what Ant has collided with
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        //If Ant has collided with a jar, destroys both objects and adds 1 to the player's score
        if (whatDidIHit.tag == "Weapon")
        {
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            Destroy(this.gameObject);
            Destroy(whatDidIHit.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1);
        }

        //If Ant has collided with the player, destroys Ant and player loses a life
        else if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().loseALife();
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
