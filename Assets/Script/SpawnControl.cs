using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject enemy1;
    public Vector2 pos;

    public Dictionary<towersBehaviour.Def, GameObject> dicio;
    public GameObject[] spawns = new GameObject[3];
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1);

        dicio = new Dictionary<towersBehaviour.Def, GameObject>()
        {
            {towersBehaviour.Def.CACTO,  spawns[0]},
            {towersBehaviour.Def.CARNIVORA, spawns[1]},
            {towersBehaviour.Def.DEFESA, spawns[2]}
        };
        
    }

    void Update()
    {
        if(towersBehaviour.selecionado != towersBehaviour.Def.NONE)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                towersBehaviour.selecionado = towersBehaviour.Def.NONE;
            }            
        }

    }
    void SpawnEnemy()
    {
        pos = new Vector2(9.74f, Random.Range(-2.16f, 2.57f));
        Instantiate(enemy1, pos, Quaternion.identity);
    }
}
