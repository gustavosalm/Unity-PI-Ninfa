using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantaBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    public float vida;
    public float dano;
    private string nome;
    private bool attacking;
    private GameObject lenhador;
    public Image barraP;
    public float vidaMax;
    private Animator anim;
    private SpriteRenderer sr;

    [SerializeField] private List<GameObject> espera;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Image barraP = gameObject.GetComponent(typeof(Image)) as Image;
        espera = new List<GameObject>();
        sr = GetComponent<SpriteRenderer>();
        //lenhador = GameObject.FindWithTag("lenhador");
    }

    // Update is called once per frame
    void Update()
    {
            
        if(espera.Count > 0 && espera[0] == null)
            espera.RemoveAt(0);
        if(espera.Count > 0)
            sr.flipX = espera[0].transform.position.x < transform.position.x;
        if (espera.Count == 0 && attacking)
        {
            print("matou");
            CancelInvoke("Atacar");
            attacking = false;
            anim.SetBool("atack", attacking);
        }
        //if (andar)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        // barraP.fillAmount = vida / vidaMax;
        // if (vida <= 0)
        //     Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "planta" && collision.tag != "arvore" && collision.tag != "placeable" && collision.tag != "seta" && collision.tag != "defesa")
        {
            print(collision.tag);
            //lenhador = collision.gameObject;
            espera.Add(collision.gameObject);
            if (espera.Count == 1 && !attacking)
            {
                InvokeRepeating("Atacar", 0.2f, 0.3f);
                attacking = true;
                anim.SetBool("atack", attacking);
            }            
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == espera[0])
        {
            espera.Remove(collision.gameObject);
        }
    }
    void Atacar()
    {
        print(dano);
        if(espera.Count > 0)
        {
            espera[0].GetComponent<Lenhador1Behaviour>().TomarDanoL(dano);
        }
        else
        {
            CancelInvoke("Atacar");
            anim.SetBool("atack", false);
        }              
    }
    public void TomarDanoP(float dano)
    {
        vida -= dano;
    }
}
