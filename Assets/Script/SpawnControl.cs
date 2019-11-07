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
    public Touch toc;

    public Dictionary<towersBehaviour.Def, GameObject> dicio;
    public GameObject[] spawns = new GameObject[3];
    public Text moedas;
    public static int dinheiro;
    private GraphicRaycaster gr;
    public GameObject[] lenhadores;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
#if UNITY_EDITOR
            RaycastHit2D raycasthit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if(towersBehaviour.selecionado == towersBehaviour.Def.DEFESA)
            {
                if(((raycasthit2D && (raycasthit2D.collider.gameObject.tag != "NoSpawn" && raycasthit2D.collider.gameObject.tag != "arvore")) || !raycasthit2D) && Input.GetButtonDown("Fire1"))
                {
                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                    dinheiro -= (int)towersBehaviour.selecionado;
                    towersBehaviour.selecionado = towersBehaviour.Def.NONE;
                }
            }
            if ((raycasthit2D && ((raycasthit2D.collider.gameObject.tag != "NoSpawn" && raycasthit2D.collider.gameObject.tag != "arvore") && raycasthit2D.collider.gameObject.tag == "placeable")) && Input.GetButtonDown("Fire1"))
            {
                raycasthit2D.collider.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                pos = raycasthit2D.collider.gameObject.transform.position;
                Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                dinheiro -= (int)towersBehaviour.selecionado;
                towersBehaviour.selecionado = towersBehaviour.Def.NONE;
            }
#elif UNITY_ANDROID
            if(toc.tapCount > 0)
            {
                toc = Input.GetTouch(0);
                RaycastHit2D raycast = Physics2D.Raycast(toc.position, Vector2.zero, Mathf.Infinity);
                if (towersBehaviour.selecionado == towersBehaviour.Def.DEFESA)
                {
                    if ((raycasthit2D && (raycasthit2D.collider.gameObject.tag != "NoSpawn" && raycasthit2D.collider.gameObject.tag != "arvore")) || !raycasthit2D)
                    {
                        pos = toc.position;
                        Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                        dinheiro -= (int)towersBehaviour.selecionado;
                        towersBehaviour.selecionado = towersBehaviour.Def.NONE;
                    }
                }
                if(raycasthit2D && ((raycasthit2D.collider.gameObject.tag != "NoSpawn" && raycasthit2D.collider.gameObject.tag != "arvore") && raycasthit2D.collider.gameObject.tag == "placeable"))
                {
                    pos = toc.position;
                    Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                    dinheiro -= (int)towersBehaviour.selecionado;
                    towersBehaviour.selecionado = towersBehaviour.Def.NONE;
                }
            }
#endif
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
        pos = /*new Vector2(9.74f, UnityEngine.Random.Range(-2.16f, 2.57f));*/ new Vector2(12f, 0.9f);
        GameObject lnh = Instantiate(lenhadores[UnityEngine.Random.Range(0, 2)], pos, Quaternion.identity);
        //lnh.GetComponent<SpriteRenderer>().sprite = lenhadores[UnityEngine.Random.Range(0,3)];
    }
}
