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
    private int spawnados;
    private bool pa;
    public Dictionary<towersBehaviour.Def, GameObject> dicio;
    public GameObject[] spawns = new GameObject[3];
    public Text moedas;
    public static int dinheiro;
    private GraphicRaycaster gr;
    public GameObject[] lenhadores;
    private List<GameObject> ordas = new List<GameObject>();
    private int i = 0;
    private int spawnsOrd = 0;
    private bool spawn = true;
    private int[] quantOrd = new int[5]{10, 15, 20, 20, 25};
    public GameObject ordaqct;
    public GameObject ws;
    void Start()
    {
        //orda 1
        Fill(10, lenhadores[0]);

        //orda 2
        Fill(4, lenhadores[0]);
        Fill(6, lenhadores[1]);
        Fill(2, lenhadores[0]);
        Fill(3, lenhadores[1]);

        //orda 3
        Fill(7, lenhadores[0]);
        Fill(5, lenhadores[1]);
        Fill(3, lenhadores[0]);
        Fill(5, lenhadores[1]);

        //orda 4
        Fill(3, lenhadores[0]);
        Fill(4, lenhadores[1]);
        Fill(2, lenhadores[0]);
        Fill(3, lenhadores[1]);
        Fill(3, lenhadores[0]);
        Fill(5, lenhadores[1]);

        //orda 5
        Fill(3, lenhadores[0]);
        Fill(22, lenhadores[1]);


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
    void Fill(int q, GameObject go)
    {
        for(int i = 0; i < q; i++)
        {
            ordas.Add(go);
        }
    }

    void Update()
    {
        if(i == 5)
        {
            i = 4;
            spawn = false;
            ws.SetActive(true);
        }
        ordaqct.GetComponent<Text>().text = (i + 1).ToString() + "/5";
        ContarMoedas();
        if(pa)
        {
            RaycastHit2D raycasthit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if(raycasthit2D && (raycasthit2D.collider.gameObject.tag == "planta" && Input.GetButtonDown("Fire1")))
            {
                raycasthit2D.collider.gameObject.GetComponent<PlantaBehavior>().lugarzin.GetComponent<CircleCollider2D>().enabled = true;
                raycasthit2D.collider.gameObject.GetComponent<PlantaBehavior>().lugarzin.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                Destroy(raycasthit2D.collider.gameObject);
                pa = false;
            }
        }
        if(towersBehaviour.selecionado != towersBehaviour.Def.NONE)
        {
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
                pos = raycasthit2D.collider.gameObject.transform.position - new Vector3(0, (towersBehaviour.selecionado == towersBehaviour.Def.CARNIVORA) ? -0.2f : 0.14f);
                GameObject planta = Instantiate(dicio[towersBehaviour.selecionado], pos, Quaternion.identity);
                planta.GetComponent<PlantaBehavior>().lugarzin = raycasthit2D.collider.gameObject;
                dinheiro -= (int)towersBehaviour.selecionado;
                raycasthit2D.collider.gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
        // if(spawnados > 10){
        //     pos = new Vector2(12f, 0.9f);
        //     GameObject lnh = Instantiate(lenhadores[UnityEngine.Random.Range(0,2)], pos, Quaternion.identity);
        // }
        // else{
        //     pos = new Vector2(12f, 0.9f);
        //     GameObject lnh = Instantiate(lenhadores[0], pos, Quaternion.identity);
        // }
        if(i < 5 && spawn)
        {
            pos = new Vector2(12f, 0.9f);
            GameObject lnh = Instantiate(ordas[spawnados], pos, Quaternion.identity);
            spawnados++;
            spawnsOrd++;
            if(spawnsOrd == quantOrd[i])
            {
                spawnsOrd -= quantOrd[i];
                i++;
                spawn = false;
                StartCoroutine("Espera");
            }
        }        
    }
    public void TirarPlanta()
    {        
        pa = true;
    }
    public IEnumerator Espera()
    {
        yield return new WaitForSeconds(3);
        spawn = true;
    }
}
