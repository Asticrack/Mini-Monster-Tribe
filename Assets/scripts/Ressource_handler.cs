using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource_handler : MonoBehaviour
{
    public string ressource_name;
    public int ressource_max;
    public int ressource_number;

    void initializeObjectRessource(string ressource_name, int ressource_max, int ressource_initial)
    {
        this.ressource_name = ressource_name;
        this.ressource_max = ressource_max;
        this.ressource_number = ressource_initial;
    }

    void add_ressource(int ressource_to_add_number)
    {
        ressource_number += ressource_to_add_number;
        if (ressource_number >= ressource_max) {
            ressource_number = ressource_max;
        }
    }

    void substract_ressource(int ressource_to_substract_number)
    {
        ressource_number -= ressource_to_substract_number;
        if (ressource_number <= 0)
        {
            ressource_number = 0;
            //TODO : supprimer l'objet ? appeler une fonction tierce ?
        }

    }

    int get_actual_ressource_number()
    {
        return this.ressource_number;
    }
    string get_ressource_name()
    {

        return this.ressource_name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
