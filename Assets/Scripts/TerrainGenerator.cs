using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    int PreviousXSize;
    int PreviousYSize;
    int PreviousZSize;
    float PreviousMaxHeight;

    [Range(1, 30)] public int xSize;
    [Range(1, 30)] public int ySize;
    [Range(1, 2)] public int zSize;
    [Range(0f, 2f)] public float MaxHeight;

    private void Update()
    {
        if (xSize != PreviousXSize || ySize != PreviousYSize || zSize != PreviousZSize || MaxHeight != PreviousMaxHeight)
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            CreateShape();
            //UpdateMesh();

            GetComponent<MeshCollider>().sharedMesh = mesh;

            PreviousXSize = xSize;
            PreviousYSize = ySize;
            PreviousZSize = zSize;
            PreviousMaxHeight = MaxHeight;
        }
    }



    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (ySize + 1) * (zSize + 1)];

        int i = 0;

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                for (int y = 0; y <= ySize; y++)
                {
                    //hauteur
                    //float y = Mathf.PerlinNoise(x * 0.3f,z * 0.3f) * MaxHeight;
                    float yy = Mathf.Sin(x) * MaxHeight;

                    vertices[i] = new Vector3(x - (xSize / 2), y - (ySize / 2) + yy, z - (zSize / 2));
                    i++;
                }
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0; 
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
