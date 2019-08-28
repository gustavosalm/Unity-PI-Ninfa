using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject enemy1;
    public Vector2 pos;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1);
    }

    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        pos = new Vector2(9.74f, Random.Range(-2.16f, 2.57f));
        Instantiate(enemy1, pos, Quaternion.identity);
    }
}
