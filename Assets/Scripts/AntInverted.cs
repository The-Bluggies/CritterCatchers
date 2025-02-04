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

    public AudioClip attackSound;
    public AudioClip collectSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        startPosition = transform.position;
        InvokeRepeating("RangedAttack", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        startPosition -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = startPosition + transform.up * -Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    void RangedAttack()
    {
        Instantiate(AcidAttack, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
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
