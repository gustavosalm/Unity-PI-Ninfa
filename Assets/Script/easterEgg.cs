using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEgg : MonoBehaviour
{
    private string[] sequ = new string[3];
    private int i = 0;
    private bool done = false;
    public GameObject tree;
    public Sprite ale;
    // Start is called before the first frame update
    void Start()
    {
        sequ[0] = "a";
        sequ[1] = "l";
        sequ[2] = "e";
        tree = GameObject.FindWithTag("arvore");
    }

    // Update is called once per frame
    void Update()
    {
        if ( !done && Input.GetKeyDown(sequ[i]))
        {
            if(i == 2)
            {
                //a
                done = true;
                tree.GetComponent<SpriteRenderer>().sprite = ale;
                tree.transform.localScale = new Vector3(0.7045772f, 0.7045772f);
                tree.GetComponent<CapsuleCollider2D>().size = new Vector2(4.754549f, 6.781902f); 
            }
            i++;
        }
        else if (!done && Input.anyKeyDown)
        {
            i = 0;
        }
    }
}
