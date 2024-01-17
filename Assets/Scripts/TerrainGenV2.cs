using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenV2 : MonoBehaviour
{
    [SerializeField] int CubeNumber;
    [SerializeField] float ValueBetweenCube;
    [SerializeField] float ValueBelowCube;
    [Header("")]
    [SerializeField, Range(1, 5)] float ValueYSin;
    [SerializeField, Range(1, 0)] float ValueXSin;
    [SerializeField, Range(0.5f, 0)] float ValueXPerlin;
    [SerializeField, Range(0, 5)] float ValueYPerlin;
    [Header("")]
    [SerializeField] GameObject CubePrefab;
    [SerializeField] List<GameObject> CubeArray;
    public Transform PlayerPos;

    private void Start()
    {
        GenerateTerrain(transform.position.x);
    }

    private void Update()
    {
        transform.position = new Vector3(PlayerPos.position.x - 9, transform.position.y);
        ChangeTerrain(transform.position.x);
    }

    void GenerateTerrain(float positionX)
    {
        for (float i = 0; i < CubeNumber; i += ValueBetweenCube)
        {
            var obj = Instantiate(CubePrefab, new Vector3(transform.position.x + i, transform.position.y), Quaternion.identity, transform);

            for (int j = 0; j < obj.GetComponent<CubeGen>().CubeMesh.vertices.Length; j++)
            {
                if (obj.GetComponent<CubeGen>().Vertices[j].x < 0 && obj.GetComponent<CubeGen>().Vertices[j].x != -ValueBetweenCube / 2)
                {
                    obj.GetComponent<CubeGen>().Vertices[j].x = -ValueBetweenCube / 2;
                }
                else if (obj.GetComponent<CubeGen>().Vertices[j].x > 0 && obj.GetComponent<CubeGen>().Vertices[j].x != ValueBetweenCube / 2)
                {
                    obj.GetComponent<CubeGen>().Vertices[j].x = ValueBetweenCube / 2;
                }

                if (obj.GetComponent<CubeGen>().Vertices[j].y > 0 && obj.GetComponent<CubeGen>().Vertices[j].y != Mathf.Sin(transform.position.x + i + obj.GetComponent<CubeGen>().Vertices[j].x) + obj.GetComponent<CubeGen>().Vertices[j].y + ValueBelowCube)
                {
                    obj.GetComponent<CubeGen>().Vertices[j].y = Mathf.Sin(positionX + i + obj.GetComponent<CubeGen>().Vertices[j].x) + obj.GetComponent<CubeGen>().Vertices[j].y + ValueBelowCube;
                }
            }

            CubeArray.Add(obj);
        }
    }

    void ChangeTerrain(float positionX)
    {
        int k = 0;

        for (float i = 0; i < CubeNumber; i += ValueBetweenCube)
        {
            for (int j = 0; j < CubeArray[k].GetComponent<CubeGen>().CubeMesh.vertices.Length; j++)
            {
                if (CubeArray[k].GetComponent<CubeGen>().Vertices[j].y > 0 && CubeArray[k].GetComponent<CubeGen>().Vertices[j].y != Mathf.Sin(positionX + i + CubeArray[k].GetComponent<CubeGen>().Vertices[j].x) + ValueBelowCube)
                {
                    float y = Mathf.PerlinNoise(Mathf.Sin((positionX + i + CubeArray[k].GetComponent<CubeGen>().Vertices[j].x) * (ValueXSin + ValueXPerlin)), ValueYSin + ValueYPerlin);
                    CubeArray[k].GetComponent<CubeGen>().Vertices[j].y = (Mathf.Sin((positionX + i + CubeArray[k].GetComponent<CubeGen>().Vertices[j].x) * ValueXSin) + y) * ValueYSin + ValueBelowCube;
                }
            }
            k++;
        }
    }
}