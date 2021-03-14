using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_actions : MonoBehaviour
{
    private bool interaction;
    private SphereCollider trigger;
    private List<Collider> reachableMonsterColliders = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<SphereCollider>();

    }

    private void OnTriggerEnter(Collider otherMonster)
    {
        if (!reachableMonsterColliders.Contains(otherMonster))
        {
            reachableMonsterColliders.Add(otherMonster);
            setInteraction(true);
        }
    }

    private void OnTriggerExit(Collider otherMonster)
    {
        if (reachableMonsterColliders.Contains(otherMonster))
        {
            reachableMonsterColliders.Remove(otherMonster);
            setInteraction(false);
        }
    }

    private void Interact()
    {
        if (!interaction) {
            return;
        }

        List<SphereCollider> otherMonstersToRemove = new List<SphereCollider>();

        foreach(SphereCollider otherMonster in reachableMonsterColliders)
        {
            if (otherMonster == null)
            {
                otherMonstersToRemove.Add(otherMonster);
                continue;
            }

            GameObject monster = otherMonster.gameObject;

            var script_tree_other_monster = monster.GetComponent<Monster>();
            var script_tree_this_monster = GetComponent<Monster>();

            if (script_tree_other_monster != null)
            {
                script_tree_other_monster.getHited(10);
                script_tree_this_monster.addHunger(10);
            }

        }

        foreach(SphereCollider otherMonster in otherMonstersToRemove)
        {
            reachableMonsterColliders.Remove(otherMonster);
        }
    }

    private void setInteraction(bool value)
    {
        interaction = value;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }
}
