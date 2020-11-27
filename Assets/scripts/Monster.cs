using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IFalling
{
    private CharacterController controller;

    private float speed = 10f;
    private Vector3 direction;
    private SphereCollider trigger;

    // Start is called before the first frame update
    void Start() {
        controller = gameObject.AddComponent<CharacterController>();
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
        Move();
        Fall();
    }

}
