using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lenhador1Behaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    public float vida;
    public float dano;
    private bool andar;
    //private string nome;
    private bool attacking;
    private GameObject tree;
    private List<GameObject> espera = new List<GameObject>();

    public Image barraL;
    public float vidaMax;
    void Start()
    {
        Image barraP = gameObject.GetComponent(typeof(Image)) as Image;
        andar = true;
        tree = GameObject.FindWithTag("arvore");
    }

    void Update()
    {
        if(espera.Count > 0 && espera[0] == null)
        {
            espera.RemoveAt(0);
        }
        //print(nome);
        if (espera.Count == 0 && attacking)
        {
            print("matou");
            CancelInvoke("Atacar");
            andar = true;
            attacking = false;
        }
        if (andar)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        barraL.fillAmount = vida / vidaMax;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {               
        if(collision.tag == "planta" || collision.tag == "arvore")
        {
            espera.Add(collision.gameObject);
            InvokeRepeating("Atacar", 0, 0.5f);
            //nome = collision.name;
            andar = false;
            attacking = true;
        }        
        //if (collision.tag == "arvore")
        //{
            //tree.GetComponent<arvoreBehaviour>().TomarDano(dano);
        //}        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("matou");
        //CancelInvoke("Atacar");
        //andar = true;
    }
    void Atacar()
    {

        print(dano);
        if(espera.Count > 0)
        {
            switch(espera[0].tag)
            {
                case "planta":
                    espera[0].GetComponent<PlantaBehavior>().TomarDanoP(dano);
                    break;
                case "arvore":
                    tree.GetComponent<arvoreBehaviour>().TomarDano(dano);
                    break;
            }
        }
        else
        {
            StopCoroutine("Atacar");
        }
        //tree.GetComponent<arvoreBehaviour>().TomarDano(dano);
    }
    public void TomarDanoL(float dano)
    {
        vida -= dano;
    }
}
