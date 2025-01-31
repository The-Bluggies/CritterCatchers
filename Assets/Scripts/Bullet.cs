using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed;

    // Start is called before the first frame update
    void Start()
    {
        bulletspeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * bulletspeed);

        if (transform.position.x >= 18.5)
        {
            Destroy(this.gameObject);
        }
    }
}
