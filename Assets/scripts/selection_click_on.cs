using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_click_on : MonoBehaviour
{
    public Material red;
    public Material green;

    private MeshRenderer new_render;
    // Start is called before the first frame update
    void Start()
    {
        new_render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clic_me()
    {
        new_render.material = green;
    }
}
