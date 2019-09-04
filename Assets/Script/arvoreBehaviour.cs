using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arvoreBehaviour : MonoBehaviour
{
    public float vida;
    private float vidaMax;
    public Image barra;
    // Start is called before the first frame update
    void Start()
    {        
        vidaMax = 100;
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = vida / vidaMax;
    }
    public void TomarDano(float dano)
    {
        vida -= dano;
    }
}
