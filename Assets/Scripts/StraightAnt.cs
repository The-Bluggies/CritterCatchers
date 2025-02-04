using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAnt : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public GameObject AcidAttack;

    public AudioClip attackSound;
    public AudioClip collectSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        InvokeRepeating("RangedAttack", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 10f);
    }

    void RangedAttack()
    {
        Instantiate(AcidAttack, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(attackSound);
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Weapon")
        {
            audioSource.PlayOneShot(collectSound);
            GameObject.Find("Player(Clone)").GetComponent<Player>().finalScore();
            Destroy(this.gameObject);
            Destroy(whatDidIHit.gameObject);

        }
        else if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().loseALife();
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
