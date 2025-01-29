using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallaxing : MonoBehaviour
{
    [SerializeField] private float layerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgParallaxing();
    }

    void bgParallaxing()
    {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * layerSpeed);

        if (transform.position.x <= -71)
        {
            transform.position = new Vector3(0, 0, 5);


        }
    }
}
