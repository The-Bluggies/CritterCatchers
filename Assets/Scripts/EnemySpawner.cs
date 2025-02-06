using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject AntSine;
    public GameObject AntInvertedSine;
    public GameObject AntStraight;
    public GameObject Isopod;

    private int AntChoice;
    private int IsoChoice;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AntSpawn", 5f, 7f);
        InvokeRepeating("IsoSpawn", 3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function in charge of randomly spawning Ants
    void AntSpawn()
    {
        AntChoice = Random.Range(1, 4);
        if (AntChoice == 1)
        {
            Instantiate(AntSine, new Vector2(20, -3), Quaternion.identity);
            Instantiate(AntInvertedSine, new Vector2(20, -3), Quaternion.identity);
        }
        
        if (AntChoice == 2)
        {
            Instantiate(AntStraight, new Vector2(20, 0), Quaternion.identity);
            Instantiate(AntStraight, new Vector2(20, -6), Quaternion.identity);
        }
        
        if (AntChoice == 3)
        {
            Instantiate(AntStraight, new Vector2(20, Random.Range(1.5f, -8.5f)), Quaternion.identity);
            Instantiate(AntStraight, new Vector2(20, Random.Range(1.5f, -8.5f)), Quaternion.identity);
        }
    }

    //Function in charge of randomly spawning Isopods
    void IsoSpawn()
    {
        IsoChoice = Random.Range(1, 5);
        if (IsoChoice == 1 || IsoChoice == 2)
        {
            Instantiate(Isopod, new Vector2(Random.Range(20f, 25f), Random.Range(1.5f, -8.5f)), Quaternion.identity);
            Instantiate(Isopod, new Vector2(Random.Range(20f, 25f), Random.Range(1.5f, -8.5f)), Quaternion.identity);
            Instantiate(Isopod, new Vector2(Random.Range(20f, 25f),Random.Range(1.5f, -8.5f)), Quaternion.identity);
        }
        
        if (IsoChoice == 3)
        {
            Instantiate(Isopod, new Vector2(20, 1.5f), Quaternion.identity);
            Instantiate(Isopod, new Vector2(20, -0.5f), Quaternion.identity);
            Instantiate(Isopod, new Vector2(20, -2.5f), Quaternion.identity);
            Instantiate(Isopod, new Vector2(20, -4.5f), Quaternion.identity);
        }
        
        if (IsoChoice == 4)
        {
            Instantiate(Isopod, new Vector2(20, -8.5f), Quaternion.identity);
            Instantiate(Isopod, new Vector2(20, -6.5f), Quaternion.identity);
            Instantiate(Isopod, new Vector2(20, -4.5f), Quaternion.identity);
            Instantiate(Isopod, new Vector2(20, -2.5f), Quaternion.identity);
        }
    }
}
