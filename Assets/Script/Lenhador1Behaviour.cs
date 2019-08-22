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
    void Start()
    {
        andar = true;
    }

    void Update()
    {
        print(nome);
        if(GameObject.Find(nome) == null)
        {
            print("matou");
            CancelInvoke("Atacar");
            andar = true;
        }
        if (andar)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nome = collision.name;
        InvokeRepeating("Atacar", Time.time, 0.5f);
        andar = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("matou");
        CancelInvoke("Atacar");
        andar = true;
    }
    void Atacar()
    {
        print(dano);
    }
}
