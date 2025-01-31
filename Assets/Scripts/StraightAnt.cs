using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAnt : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public GameObject AcidAttack;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Weapon")
        {
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
