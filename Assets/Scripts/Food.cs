using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int foodGet = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().hungry += foodGet;

            if (other.GetComponent<Player>().hungry > 100)
                other.GetComponent<Player>().hungry = 100;

            Destroy(this.gameObject);
        }
    }
}
