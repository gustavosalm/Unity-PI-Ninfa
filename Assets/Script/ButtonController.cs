using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject triangulo;
    public GameObject hexagono;
    private Vector2 posicao;
    bool spawnTri;
    bool spawnHex;
    void Start()
    {
        
    }

    void Update()
    {
        if(spawnTri)
        {
            if (Input.GetMouseButtonDown(0))
            {
                posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(triangulo, posicao, Quaternion.identity);
                spawnTri = false;
            }
        }
        if (spawnHex)
        {
            if (Input.GetMouseButtonDown(0))
            {
                posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(hexagono, posicao, Quaternion.identity);
                spawnHex = false;
            }
        }

    }
    public void SpawnarTriangulo()
    {
        spawnTri = true;        
    }
    public void SpawnarHexagono()
    {
        spawnHex = true; 
    }
}
