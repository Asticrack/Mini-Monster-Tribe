using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_click : MonoBehaviour
{
    public LayerMask clickable_layer;
    public GameObject currently_selected;
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
                if (!currently_selected)
                {
                    currently_selected = ray_hit.transform.gameObject;
                }
                else if (ray_hit.transform.gameObject != currently_selected)
                {
                    unselect_currently_selected();
                    currently_selected = ray_hit.transform.gameObject;

                }
            }
        }
    }

    private void unselect_currently_selected()
    {
        currently_selected.GetComponent<selection_click_on>().destroy_information_text_object();
        currently_selected.GetComponent<selection_click_on>().is_selected = false;
    }
}
