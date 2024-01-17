using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float valueSpeedGameOver = 0.5f;
    [SerializeField] float BeginForce = 5;
    [SerializeField] float gravityVelocity = 1.5f;
    [SerializeField] float velocityOnGround = 0.5f;
    [SerializeField] float yForceUp = 1f;
    [SerializeField] float yForceDown = -1f;
    [SerializeField] float rotationSpeed = 10f;
    Rigidbody rigidbody;

    [SerializeField] Transform CameraTransform;
    [SerializeField] Transform ControlTransform;
    [SerializeField] Transform ParalaxTransform;
    Player playerStats;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerStats = GetComponent<Player>();

        rigidbody.AddForce(new Vector3(1,1,0) * BeginForce, ForceMode.Impulse);
    }

    private void Update()
    {
        CameraTransform.position = new Vector3(transform.position.x, transform.position.y, CameraTransform.position.z);
        ParalaxTransform.position = new Vector3(transform.position.x, transform.position.y, ParalaxTransform.position.z);
        ControlTransform.position = transform.position;

        if (playerStats.speedValueFloat / 100f > 0.0015f)
        {
            ParalaxTransform.GetComponent<ParralaxManager>().UpdateParallax(playerStats.speedValueFloat/100f, transform.position.x);
        }
        else
        {
            ParalaxTransform.GetComponent<ParralaxManager>().UpdateParallax(0.0015f, transform.position.x);
        }

        Debug.Log(playerStats.speedValueFloat / 100f);

        float yOffSet = 0;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            yOffSet = yForceUp;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            yOffSet = yForceDown;
        }

        rigidbody.AddForce(Vector3.up * (gravityVelocity + yOffSet));

        if (rigidbody.velocity.magnitude <= valueSpeedGameOver)
        {
            playerStats.GameOver();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Food>() && !other.GetComponent<Drink>() && playerStats.lubricant / 100 > 0)
            rigidbody.AddForce(rigidbody.velocity * velocityOnGround, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        ControlTransform.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.y * rotationSpeed);
    }
}
