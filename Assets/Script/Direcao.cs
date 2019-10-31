using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direcao : MonoBehaviour
{
    public enum Direc{RIGHT, LEFT, UP, DOWN};
    public Direc seta;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        switch (seta)
        {
            case Direc.RIGHT:
                direction = Vector2.right;
                break;
            case Direc.LEFT:
                direction = Vector2.left;
                break;
            case Direc.UP:
                direction = Vector2.up;
                break;
            case Direc.DOWN:
                direction = Vector2.down;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
