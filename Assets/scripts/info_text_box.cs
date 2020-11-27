using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info_text_box : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject children_3d_text;
    public GameObject children_3d_box;
    public GameObject main_camera_of_the_scene;
    public Transform target;
    public Vector3 y_pos_factor = new Vector3(0, 3, 0);
    public Bounds bounds_of_3d_text;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = main_camera_of_the_scene.transform.position + y_pos_factor;
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);
        bounds_of_3d_text = children_3d_text.GetComponent<Renderer>().bounds;
        children_3d_text.GetComponent<TextMesh>().text = "actual position = " + this.transform.position.ToString();
        children_3d_text.GetComponent<TextMesh>().text += "\nactual scale 3Dtext = " + children_3d_text.GetComponent<Renderer>().bounds.ToString();
        children_3d_text.GetComponent<TextMesh>().text += "\nactual scale 3Dbox = " + children_3d_box.GetComponent<Transform>().localScale.ToString();
        Vector3 actual_scale = children_3d_box.GetComponent<Transform>().localScale;
        children_3d_text.GetComponent<Transform>().localPosition = new Vector3(bounds_of_3d_text.extents.x, bounds_of_3d_text.extents.y, 0.1F);
        children_3d_box.GetComponent<Transform>().localScale = new Vector3(bounds_of_3d_text.extents.x*2+2, bounds_of_3d_text.extents.y * 2 + 1, 0.1F);
    }

    public void initiate_position()
    {
        this.transform.position = main_camera_of_the_scene.transform.position + y_pos_factor;
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);
    }
}
