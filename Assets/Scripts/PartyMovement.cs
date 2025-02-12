using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float turnSpeed = 45.0f;
    public float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the Vehicle Forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // turning based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }
}
