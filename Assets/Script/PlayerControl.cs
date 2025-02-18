using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; 
    public float rotationSpeed = 120.0f; 

    private Rigidbody rb; 


    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}