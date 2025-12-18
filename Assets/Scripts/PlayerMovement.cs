using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 5f;
    Rigidbody rb;

    public Transform mainCam;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        
        Vector3 camForward = mainCam.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = mainCam.right;
        camRight.y = 0f;
        camRight.Normalize();

        
        Vector3 movement = (camForward * moveZ + camRight * moveX).normalized;

        
        if (movement.magnitude > 0.1f)
        {
            float targetY = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetY, 0f);
            rb.MoveRotation(targetRotation);
        }

        
        Vector3 moveForce = movement * speed;
        rb.velocity = new Vector3(moveForce.x, rb.velocity.y, moveForce.z);
    }
}

