using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IFalling
{

    public int health = 100;
    public int hunger = 100;
    public int thirst = 100;

    public float hungerDecrementTime = 0.5f;
    public float thirstDecrementTime = 0.5f;
    public float healthDecrementTime = 0.5f;

    private float hungerTimer = 0.0f;
    private float thirstTimer = 0.0f;
    private float healthTimer = 0.0f;

    private CharacterController controller;

    private bool interaction = false;
    private float speed = 1f;
    private Vector3 direction = Vector3.zero;
    private SphereCollider trigger;
    private List<Collider> reachableColliders = new List<Collider>();

    // Start is called before the first frame update
    void Start() {
        controller = gameObject.AddComponent<CharacterController>();
        if(controller == null)
        {
            controller = gameObject.GetComponent<CharacterController>();
        }
        trigger = GetComponent<SphereCollider>();
        Physics.IgnoreCollision(GetComponent<SphereCollider>(), GetComponent<CharacterController>());
        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), GetComponent<CharacterController>());
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if(!reachableColliders.Contains(other)) {
            reachableColliders.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("exit collision with " + other);
        if (reachableColliders.Contains(other))
        {
            reachableColliders.Remove(other);
        }
    }

    void Interact() {
        if(!interaction) {
            return;
        }
        //Debug.Log("SHRECK IS LOVE");
        List<Collider> objectsToRemove = new List<Collider>();

        foreach(Collider other in reachableColliders) {
            if(other == null)
            {
                objectsToRemove.Add(other);
                continue;
            }
            GameObject otherObject = other.gameObject;

            var script_tree = otherObject.GetComponent<Tree_resource>();
            if (script_tree != null)
            {
                Debug.Log(script_tree.displayInformation());
                script_tree.getWood(1); // RECOLTE DES RESSOURCES ICI
                return;
            }
            var script_water = otherObject.GetComponent<Water_resource>();
            if (script_water != null)
            {
                Debug.Log(script_water.displayInformation());
                script_water.takeRessourceWithQuantity(1); // RECOLTE DES RESSOURCES ICI
                return;
            }
            var script_bush = otherObject.GetComponent<FruityBush_resource>();
            if (script_bush != null)
            {
                Debug.Log(script_bush.displayInformation());
                script_bush.recolteUneQuantiteDeFruits(1); // RECOLTE DES RESSOURCES ICI
                return;
            }

            var script_tree_other_monster = otherObject.GetComponent<Monster>();
            if (script_tree_other_monster != null && isABadMonster() && (script_tree_other_monster.isACoolMonster() || script_tree_other_monster.isPlayerMonster()) )
            {
                script_tree_other_monster.getHitted(5, otherObject);
                hitMonster(5, otherObject);
                return;
            }
            if (script_tree_other_monster != null && (isACoolMonster() || isPlayerMonster()) &&script_tree_other_monster.isABadMonster())
            {
                script_tree_other_monster.hitMonster(5, gameObject);
                getHitted(5, otherObject);
                return;
            }

        }

        foreach(Collider removable in objectsToRemove)
        {
            reachableColliders.Remove(removable);
        }
    }

    public void SetDirection(Vector3 translation) {
        direction = Vector3.Normalize(translation);
    }

    public void setInteraction(bool value) {
        interaction = value;
    }

    public void hitMonster(int foodQuantity, GameObject hittedMonster)
    {
        print(System.String.Format("{0} hitted {1} and won +{2} food quantity", gameObject, hittedMonster, foodQuantity));
        if (hunger < 100 && (100 - foodQuantity) >= hunger)
        {
            hunger += foodQuantity;
        } else if (hunger < 100 & (100 - foodQuantity) < hunger)
        {
            hunger += (100 - foodQuantity);
        }
        Debug.Log("Hunger = " + hunger);
    }

    public void getHitted(int damage, GameObject badMonster)
    {
        print(System.String.Format("{0} got hitted by {1} and lost -{2} points of health", gameObject, badMonster, damage));
        if (health - damage <= 0)
        {
            health = 0;
        } else
        {
            health -= damage;
        }
        Debug.Log("Health = " + health);
    }

    public void Fall() {
        controller.Move(new Vector3(0, Gravity.FORCE, 0) * Time.deltaTime);
    }

    public void Move() {
        controller.Move(direction * speed * Time.deltaTime);
    }

    public bool isABadMonster()
    {
        return gameObject.ToString().Contains("bad");
    }

    public bool isACoolMonster()
    {
        return gameObject.ToString().Contains("cool");
    }

    public bool isPlayerMonster()
    {
        return gameObject.ToString().Contains("player");
    }

    // Update is called once per frame
    void Update() {
        UpdateAttributes(Time.deltaTime);
        Interact();
        Move();
        Fall();
    }

    private void UpdateAttributes(float deltaTime) {
        hungerTimer += deltaTime;
        thirstTimer += deltaTime;
        healthTimer += deltaTime;

        if (hungerTimer / hungerDecrementTime > 1.0f)
        {
            hunger = Mathf.Max(0, hunger - Mathf.FloorToInt(hungerTimer / hungerDecrementTime));
            hungerTimer = hungerTimer % hungerDecrementTime;
        }

        if (thirstTimer / thirstDecrementTime > 1.0f)
        {
            thirst = Mathf.Max(0, thirst - Mathf.FloorToInt(thirstTimer / thirstDecrementTime));
            thirstTimer = thirstTimer % thirstDecrementTime;
        }

        if (healthTimer / healthDecrementTime > 1.0f)
        {
            if (hunger == 0)
            {
                health = Mathf.Max(0, health - Mathf.FloorToInt(healthTimer / healthDecrementTime));
            }
            if (thirst == 0)
            {
                health = Mathf.Max(0, health - Mathf.FloorToInt(healthTimer / healthDecrementTime));
            }
            healthTimer = healthTimer % healthDecrementTime;
        }
    }

}
