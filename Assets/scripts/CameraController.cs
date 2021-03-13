using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 newPosition;
    public float movementSpeed;
    private float interpolationSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
    }

    void handleInput()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            newPosition += (new Vector3(0, 0, 1) * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            newPosition += (new Vector3(0, 0, 1) * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * interpolationSpeed);
    }
}
