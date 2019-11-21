using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class towersBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Def
    {
        NONE = 0,
        CACTO = 5,
        CARNIVORA = 11,
        DEFESA = 15
    }
    public Def cards;
    public static Def selecionado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Button>().interactable = ((int)cards > SpawnControl.dinheiro) ? false : true;
    }
    public void SelecionarPlanta(Button planta)
    {
        selecionado = planta.GetComponent<towersBehaviour>().cards;
    }

}
