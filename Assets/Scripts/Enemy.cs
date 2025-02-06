using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy: MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public AudioClip collectSound;
   // public AudioClip enemySound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

        if (transform.position.x <= -20)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy left the game");
        }
    }

    void EnemyMovement()
    {
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 10f);
       // AudioSource.PlayClipAtPoint(enemySound, Player.transform.position);
    }

    //Function that checks to see what Enemy has collided with
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        //If Enemy has collided with a jar, destroys both objects and adds 1 to the player's score
        if (whatDidIHit.tag == "Weapon")
        {
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            Destroy(this.gameObject);
            Destroy(whatDidIHit.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1);
        } 
        
        //If Enemy has collided with the player, destroys Enemy and player loses a life
        else if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().loseALife();
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
