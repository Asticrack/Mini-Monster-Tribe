using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class press_escape_to_enable_or_disable_in_game_menu : MonoBehaviour
{
    public GameObject in_game_canvas ;
    public GameObject in_game_canvas_main_menu;
    public GameObject in_game_canvas_scene_selection;
    public List<GameObject> objects_of_the_scene;
    public list_all_objects_in_scene laois_script;

    // Start is called before the first frame update
    void Start()
    {
        //laois_script.test_function();
        objects_of_the_scene = laois_script.get_all_objects_in_scene();
        in_game_canvas = get_Object_in_list_by_name("in_game_canvas");
        in_game_canvas_main_menu = get_Object_in_list_by_name("main menu");
        in_game_canvas_scene_selection = get_Object_in_list_by_name("scene selection");
        //get_objects_script.get_all_objects_in_scene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && in_game_canvas.activeInHierarchy)
        {
            if (in_game_canvas_scene_selection.activeInHierarchy) {
                in_game_canvas_main_menu.SetActive(true);
                in_game_canvas_scene_selection.SetActive(false);
            }
            
            in_game_canvas.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !in_game_canvas.activeInHierarchy)
        {
            in_game_canvas.SetActive(true);
        }

    }

    GameObject get_Object_in_list_by_name(string name)
    {
        foreach (GameObject objet in objects_of_the_scene)
        {
            if(objet.name == name)
            {
                return objet;
            }
        }

        return null;
    }
}
