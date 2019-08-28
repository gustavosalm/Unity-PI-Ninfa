using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject triangulo;
    public GameObject hexagono;
    private Vector2 posicao;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SpawnarTriangulo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(triangulo, posicao, Quaternion.identity);
        }
    }
    public void SpawnarHexagono()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(hexagono, posicao, Quaternion.identity);
        }
    }
}
