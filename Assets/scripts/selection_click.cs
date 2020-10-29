using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_click : MonoBehaviour
{
    public LayerMask clickable_layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit ray_hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray_hit, Mathf.Infinity, clickable_layer))
            {
                ray_hit.collider.GetComponent<selection_click_on>().clic_me();
            }
        }
    }
}
