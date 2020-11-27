using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_click_on : MonoBehaviour
{
    public Material red;
    public Material green;
    public Boolean is_selected = false;
    public GameObject information_text_object;
    public GameObject test;
    public float z_spawn_factor = 2;
    private MeshRenderer new_render;
    // Start is called before the first frame update
    void Start()
    {
        //new_render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clic_me(GameObject info_text_box)
    {
        if (!is_selected)
        {
            //information_text_object = GameObject.CreatePrimitive(PrimitiveType.Cube);
            test = Instantiate(info_text_box, this.gameObject.transform.position + new Vector3(0, z_spawn_factor, 0), Quaternion.identity);
            test.GetComponent<info_text_box>().main_camera_of_the_scene = this.gameObject;
            test.GetComponent<info_text_box>().initiate_position();
            test.active = true;
            //information_text_object.transform.position = this.gameObject.transform.position + new Vector3(0, z_spawn_factor, 0);
            is_selected = true;
        }
        
        //new_render.material = green;
    }

    public void destroy_information_text_object()
    {
        Destroy(test);
        information_text_object = null;
    }
}
