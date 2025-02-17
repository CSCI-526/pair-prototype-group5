using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController player;
    public float speed = 5f;
    public float rotationSpeed = 10f; // Smooth rotation speed


    void Start()
    {
        player = GetComponent<CharacterController>();
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down

        Vector3 move = new Vector3(horizontal, 0, vertical);

        // Move the object
        transform.Translate(move.normalized * speed * Time.deltaTime, Space.World);

        // Rotate smoothly when moving
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        player.SimpleMove(move * 10);
    }
}