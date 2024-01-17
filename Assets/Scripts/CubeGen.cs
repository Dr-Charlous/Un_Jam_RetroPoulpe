using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGen : MonoBehaviour
{
    [SerializeField] Mesh CubeMeshRef;
    public Vector3[] Vertices;
    public Mesh CubeMesh;
    Vector3[] VerticesPreviousPos;
    Vector3 VerticesMove;
    Vector3 VerticesMoveNext;

    private void Awake()
    {
        CubeMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = CubeMesh;

        CubeMesh.vertices = CubeMeshRef.vertices;
        CubeMesh.triangles = CubeMeshRef.triangles;
        
        GetComponent<MeshCollider>().sharedMesh = CubeMesh;
        CubeMesh.RecalculateNormals();

        VerticesPreviousPos = CubeMesh.vertices;
        Vertices = CubeMesh.vertices;
    }

    private void Update()
    {
        Check();
        Action();

        CubeMesh.vertices = Vertices;
        GetComponent<MeshCollider>().sharedMesh = CubeMesh;
        GetComponent<MeshCollider>().sharedMesh.RecalculateBounds();

    }

    void Check()
    {
        for (int i = 0; i < Vertices.Length; i++)
        {
            if (VerticesPreviousPos[i] != Vertices[i])
            {
                VerticesMove = VerticesPreviousPos[i];
                VerticesMoveNext = Vertices[i];
                break;
            }
        }
    }

    void Action()
    {
        for (int i = 0; i < Vertices.Length; i++)
        {
            if (VerticesPreviousPos[i] != VerticesMoveNext && VerticesPreviousPos[i] == VerticesMove)
            {
                Vertices[i] = VerticesMoveNext;
                VerticesPreviousPos[i] = VerticesMoveNext;
            }
        }
    }
}
