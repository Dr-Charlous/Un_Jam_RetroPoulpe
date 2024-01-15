using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] float value = 0;
    [SerializeField] GameObject Ball;

    private void Update()
    {
        value += Time.deltaTime;
        Debug.Log(Mathf.Sin(value));
        Ball.transform.position = new Vector3(transform.position.x, Mathf.Sin(value), transform.position.z);
    }
}
