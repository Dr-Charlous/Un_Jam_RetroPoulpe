using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Rigidbody rigidbody;

    [SerializeField] Transform CameraTransform;
    [SerializeField] Transform ControlTransform;

    private void Update()
    {
        CameraTransform.position = new Vector3(transform.position.x, transform.position.y, CameraTransform.position.z);
        ControlTransform.position = transform.position;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            rigidbody.velocity = Vector3.up * velocity;
        }
    }

    private void FixedUpdate()
    {
        ControlTransform.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.y * rotationSpeed);
    }
}
