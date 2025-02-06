using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAnt : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public GameObject AcidAttack;

    public AudioClip collectSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RangedAttack", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 11)
        {
            EnemyMovement();
        }
    }

    void EnemyMovement()
    {
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 10f);
    }

    void RangedAttack()
    {
        Instantiate(AcidAttack, transform.position, Quaternion.identity);
    }

    //Function that checks to see what StraightAnt has collided with
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        //If StraightAnt has collided with a jar, destroys both objects and adds 1 to the player's score
        if (whatDidIHit.tag == "Weapon")
        {
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            Destroy(this.gameObject);
            Destroy(whatDidIHit.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1);
        }

        //If StraightAnt has collided with the player, destroys StraightAnt and player loses a life
        else if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().loseALife();
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
