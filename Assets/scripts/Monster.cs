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

    private float speed = 10f;
    private Vector3 direction = Vector3.zero;
    private SphereCollider trigger;

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
        UnityEngine.Debug.Log(other);
    }

    public void SetDirection(Vector3 translation)
    {
        direction = Vector3.Normalize(translation);
    }

    public void Fall()
    {
        controller.Move(new Vector3(0, Gravity.FORCE, 0) * Time.deltaTime);
    }

    public void Move()
    {
        controller.Move(direction * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        updateAttributes(Time.deltaTime);
        Move();
        Fall();
    }

    private void updateAttributes(float deltaTime) {
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
