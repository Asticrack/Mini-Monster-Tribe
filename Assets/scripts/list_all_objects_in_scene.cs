
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class list_all_objects_in_scene : MonoBehaviour
{
    public List<GameObject> all_objects_of_the_scene = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //    #if UNITY_EDITOR

    public List<GameObject> get_all_objects_in_scene()
    { 
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
            all_objects_of_the_scene.Add(go);
        }
        return all_objects_of_the_scene;
    }
    // #end if
    public void test_function()
    {
        Debug.Log("the function test_function was called");
    }
}


