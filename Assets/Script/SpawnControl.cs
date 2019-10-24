using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnControl : MonoBehaviour
{
    public GameObject enemy1;
    public Vector2 pos;

    public Dictionary<towersBehaviour.Def, GameObject> dicio;
    public GameObject[] spawns = new GameObject[3];
    public Text moedas;
    public static int dinheiro;
    private GraphicRaycaster gr;
    public Sprite[] lenhadores;
    void Start()
    {
        gr = this.GetComponent<GraphicRaycaster>();
        dinheiro = 10;
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
        ContarMoedas();
        if(towersBehaviour.selecionado != towersBehaviour.Def.NONE)
        {
            RaycastHit2D raycasthit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (((raycasthit2D && raycasthit2D.collider.gameObject.tag != "NoSpawn") || !raycasthit2D) && Input.GetButtonDown("Fire1"))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                dinheiro -= (int)towersBehaviour.selecionado;
                towersBehaviour.selecionado = towersBehaviour.Def.NONE;
            }
        }
    }
    private PointerEventData PointerEventData(object p)
    {
        throw new NotImplementedException();
    }

    void ContarMoedas()
    {
        if(dinheiro < 10)
        {
            moedas.text = "0" + dinheiro;
        }
        else
        {
            moedas.text = dinheiro.ToString();
        }
    }
    void SpawnEnemy()
    {
        pos = new Vector2(9.74f, UnityEngine.Random.Range(-2.16f, 2.57f));
        GameObject lnh = Instantiate(enemy1, pos, Quaternion.identity);
        lnh.GetComponent<SpriteRenderer>().sprite = lenhadores[UnityEngine.Random.Range(0,3)];
    }
}
