using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicRayCanvas : MonoBehaviour
{
    private GraphicRaycaster gr;
    private EventSystem es;
    private PointerEventData ped;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        gr = this.GetComponent<GraphicRaycaster>();
        es = this.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetButtonDown("Fire1"))
        {
            ped = new PointerEventData(es);
            ped.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            gr.Raycast(ped, results);

            //PointerEventData ped = new PointerEventData(es);
            //ped.position = Input.mousePosition;
            //gr.Raycast(ped, results);
            foreach (RaycastResult a in results)
            {
                print(a);
            }
        }
    }
}
