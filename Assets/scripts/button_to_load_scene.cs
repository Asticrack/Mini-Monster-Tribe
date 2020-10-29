using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_to_load_scene : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene_name;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    void OnMouseUp()
    {
       
    }
    public void load_scene()
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Single);

    }
}
