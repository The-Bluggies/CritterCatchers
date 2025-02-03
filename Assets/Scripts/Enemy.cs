using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Weapon")
        {
            Destroy(this.gameObject);
            Destroy(whatDidIHit.gameObject);

        } else if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().loseALife();
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
