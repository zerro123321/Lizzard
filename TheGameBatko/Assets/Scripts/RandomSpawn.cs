using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject coin;
    public float spawnRate = 2f;
    public float nextSpawn = 0f;
    int whatToSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 5);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(coin, transform.position, Quaternion.identity);
                    break;
            }
            

        }
        nextSpawn = Time.time + spawnRate;
    }
}
