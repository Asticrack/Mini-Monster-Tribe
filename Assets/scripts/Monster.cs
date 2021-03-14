using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IFalling
{

    public int health = 100;
    public int hunger = 100;
    public int thirst = 100;

    public float hungerDecrementTime = 5.0f;
    public float thirstDecrementTime = 5.0f;
    public float healthDecrementTime = 5.0f;

    private float hungerTimer = 0.0f;
    private float thirstTimer = 0.0f;
    private float healthTimer = 0.0f;

    private CharacterController controller;

    private bool interaction = false;
    private float speed = 10f;
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
        if(!reachableColliders.Contains(other)) {
            reachableColliders.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit collision with " + other);
        if (reachableColliders.Contains(other))
        {
            reachableColliders.Remove(other);
        }
    }

    void Interact() {
        if(!interaction) {
            return;
        }

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

    public void Fall() {
        controller.Move(new Vector3(0, Gravity.FORCE, 0) * Time.deltaTime);
    }

    public void Move() {
        controller.Move(direction * speed * Time.deltaTime);
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

        if (hungerTimer / hungerDecrementTime > 1f)
        {
        hunger -= Mathf.Max(0, Mathf.FloorToInt(hungerTimer / hungerDecrementTime));
        hungerTimer = hungerTimer % hungerDecrementTime;
        }

        if (thirstTimer / thirstDecrementTime > 1f)
        {
        thirst -= Mathf.Max(0, Mathf.FloorToInt(thirstTimer / thirstDecrementTime));
        thirstTimer = thirstTimer % thirstDecrementTime;
        }

        if (healthTimer / healthDecrementTime > 1f)
        {
        if (hunger == 0f)
        {
            health -= Mathf.Max(0, Mathf.FloorToInt(healthTimer / healthDecrementTime));
        }
        if (thirst == 0f)
        {
            health -= Mathf.Max(0, Mathf.FloorToInt(healthTimer / healthDecrementTime));
        }
        healthTimer = healthTimer % healthDecrementTime;
        }
    }

}
