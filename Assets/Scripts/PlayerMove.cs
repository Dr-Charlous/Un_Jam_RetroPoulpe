using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float velocity = 1.5f;
    [SerializeField] float yForceUp = 1f;
    [SerializeField] float yForceDown = -1f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Rigidbody rigidbody;

    [SerializeField] Transform CameraTransform;
    [SerializeField] Transform ControlTransform;
    [SerializeField] Transform ParalaxTransform;

    private void Start()
    {
        rigidbody.AddForce(new Vector3(1,1,0) * velocity, ForceMode.Impulse);
    }

    private void Update()
    {
        CameraTransform.position = new Vector3(transform.position.x, transform.position.y, CameraTransform.position.z);
        ParalaxTransform.position = new Vector3(transform.position.x, transform.position.y, ParalaxTransform.position.z);
        ControlTransform.position = transform.position;
        ParalaxTransform.GetComponent<ParralaxManager>().UpdateParallax(rigidbody.velocity.magnitude/100);

        float yOffSet = 0;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            yOffSet = yForceUp;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            yOffSet = yForceDown;
        }

        rigidbody.AddForce(Vector3.up * (velocity + yOffSet));
    }

    private void FixedUpdate()
    {
        //ControlTransform.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.y * rotationSpeed);
    }
}
