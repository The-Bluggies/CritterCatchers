using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntInverted : MonoBehaviour
{
    private Vector3 startPosition;

    [SerializeField] private float moveSpeed = 6f;

    [SerializeField] private float frequency = 5f;

    [SerializeField] private float magnitude = 5f;

    [SerializeField] private float offset = 0f;

    public GameObject Player;
    public GameObject Bullet;
    public GameObject AcidAttack;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        InvokeRepeating("RangedAttack", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        InvertSine();

    }

    void InvertSine()
    {
        if (transform.position.x >= 11)
        {
            startPosition -= transform.right * Time.deltaTime * moveSpeed;
            transform.position = startPosition + transform.up * -Mathf.Sin(Time.time * frequency + offset) * magnitude;
        } else
        {
            transform.position = startPosition + transform.up * -Mathf.Sin(Time.time * frequency + offset) * magnitude;
        }
    }

    void RangedAttack()
    {
        Instantiate(AcidAttack, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
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
