using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    private Monster monster;
    private MonsterAnimation monsterAnimation;

    private Vector3 nextMove;
    // Start is called before the first frame update
    void Start()
    {
        monster = gameObject.GetComponent<Monster>() as Monster;
        monsterAnimation = gameObject.GetComponentInChildren<MonsterAnimation>() as MonsterAnimation;
    }

    private void move()
    {
        nextMove = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("up");
            nextMove.z += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("DownArrow");

            nextMove.z -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("LeftArrow");

            nextMove.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("RightArrow");

            nextMove.x += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            monster.setInteraction(true);
        }
        else {
            monster.setInteraction(false);
        }

        monster.SetDirection(nextMove);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
