using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    private Monster monster;

    private Vector3 nextMove;
    // Start is called before the first frame update
    void Start()
    {
        monster = gameObject.GetComponent<Monster>() as Monster;
    }

    private void move()
    {
        nextMove = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            nextMove.z += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            nextMove.z -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nextMove.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            nextMove.x += 1;
        }
        monster.SetDirection(nextMove);
    }

    private void interact()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Trying to interact");
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
        interact();
    }
}
