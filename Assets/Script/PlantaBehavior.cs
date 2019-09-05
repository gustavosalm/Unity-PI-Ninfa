using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    public float vida;
    public float dano;
    private bool andar;
    private string nome;
    private bool attacking;
    private GameObject lenhador;

    [SerializeField] private List<GameObject> espera;
    // Start is called before the first frame update
    void Start()
    {
        andar = true;
        espera = new List<GameObject>();
        InvokeRepeating("Atacar", 0, 0.5f);
        //lenhador = GameObject.FindWithTag("lenhador");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(nome) == null && attacking)
        {
            print("matou");
            //CancelInvoke("Atacar");
            andar = true;
            attacking = false;
        }
        if (andar)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nome = collision.name;
        //lenhador = collision.gameObject;
        espera.Add(collision.gameObject);
        andar = false;
        attacking = true;
    }
    void Atacar()
    {
        print(dano);
        if(espera.Count > 0)
        {
            if(espera[0] == null)
            {
                espera.RemoveAt(0);
            }
            else
            {
                espera[0].GetComponent<Lenhador1Behaviour>().TomarDanoL(dano);
            }
        }
        else
        {
            andar = true;
        }
              
    }
}
