using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenhador1Behaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    public float vida;
    public float dano;
    private bool andar;
    private string nome;
    private bool attacking;
    private GameObject tree;
    void Start()
    {
        andar = true;
        tree = GameObject.FindWithTag("arvore");
    }

    void Update()
    {
        //print(nome);
        if (GameObject.Find(nome) == null && attacking)
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nome = collision.name;
        InvokeRepeating("Atacar", 0, 0.5f);
        andar = false;
        attacking = true;
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
        tree.GetComponent<arvoreBehaviour>().TomarDano(dano);
    }
}
