using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outliner : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
        outlineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlinedObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend = outlinedObject.GetComponent<Renderer>();

        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlinedObject.GetComponent<outliner>().enabled = false;
        outlinedObject.GetComponent<Collider>().enabled = false;

        rend.enabled = false;

        return rend;
    }
}
