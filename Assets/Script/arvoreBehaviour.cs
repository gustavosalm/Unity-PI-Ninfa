
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arvoreBehaviour : MonoBehaviour
{
    public float vida;
    private float vidaMax;
    public Image barraA;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {        
        vidaMax = 1000;
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        barraA.fillAmount = vida / vidaMax;
        if(vida <= 0)
            go.SetActive(true);
    }
    public void TomarDano(float dano)
    {
        vida -= dano;
    }
}
