using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawnManager : MonoBehaviour
{
    public int maxCount;
    public int carCount;
    public Transform[] spawnPoints;
    public GameObject[] car;

    public float spawnTime;
    public float curTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = Random.Range(.3f, 1.5f);
        if (curTime >= spawnTime && carCount < maxCount)
        {
            int x = Random.Range(0, spawnPoints.Length);
            int y = Random.Range(0, car.Length);
            SpawnCar(x, y);

        }
        curTime += Time.deltaTime;

    }

    public void SpawnCar(int spawnN, int carN)
    {
        curTime = 0;
        carCount++;
        Instantiate(car[carN], spawnPoints[spawnN]);

    }

}
