using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Vector3 dir = new Vector3(1, 1, 0);
    public float jumpIntensity=3;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(dir * jumpIntensity);
    }
    
}
