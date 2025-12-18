using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;  

    public Vector3 offset = new Vector3(0, 50, -100);
    public float smoothSpeed = 1f;
    public float sensitivity = 5f;
    public float minPitch = -30f;
    public float maxPitch = 80f;
    private float yaw = 0f;
    private float pitch = 25f;

    void LateUpdate()
    {
        if (target == null) return;

        
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

       
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        
        Vector3 desiredPosition = target.position + rotation * offset;

        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        
        transform.LookAt(target);
    }
}
