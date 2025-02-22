using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float turnSpeed = 45.0f;
    public float speed = 10.0f;
    public Transform cameraTransform; // Reference to the camera

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Get the forward and right direction from the camera
        Vector3 forward = cameraTransform.forward;

        // Flatten the directions to ignore vertical rotation of camera
        forward.y = 0;
        forward.Normalize();

        // Move the player relative to the camera direction
        Vector3 moveDirection = (forward * verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    

        // Rotate the player to face movement direction (optional)
        // if (moveDirection != Vector3.zero)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        // }
    }
}