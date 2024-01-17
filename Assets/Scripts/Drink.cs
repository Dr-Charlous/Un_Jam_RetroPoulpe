using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] int waterGet = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().lubricant += waterGet;

            if (other.GetComponent<Player>().lubricant > 100)
                other.GetComponent<Player>().lubricant = 100;

            Destroy(this.gameObject);
        }
    }
}
