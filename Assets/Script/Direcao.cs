using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direcao : MonoBehaviour
{
    public enum Direc{RIGHT, LEFT, UP, DOWN};
    public Direc seta;
    public Vector2 direction;
    public string anim;
    //public SpriteRenderer lenhador;

    // Start is called before the first frame update
    void Start()
    {
        switch (seta)
        {
            case Direc.RIGHT:
                //lenhador = GetComponent<SpriteRenderer>();
                //lenhador.flipX = true;
                direction = Vector2.right;
                anim = "direita";
                break;
            case Direc.LEFT:
                direction = Vector2.left;
                anim = "esquerda";
                break;
            case Direc.UP:
                direction = Vector2.up;
                anim = "cima";
                break;
            case Direc.DOWN:
                direction = Vector2.down;
                anim = "baixo";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
