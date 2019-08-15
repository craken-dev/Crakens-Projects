using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    [SerializeField] private int x_size = 20;
    [SerializeField] private int z_size = 20;
    [SerializeField] private float factor = .3f;
    private int array_size;

    Vector3[] vertecies;
    int[] triangles;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        array_size = (x_size + 1) * (z_size + 1);

        Camera.main.transform.position = new Vector3(x_size / 2, Camera.main.transform.position.y, Camera.main.transform.position.z);

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertecies = new Vector3[array_size];

        for(int z = 0, index = 0;  z <= z_size; z++)
        {
            for(int x = 0; x <= x_size; x++)
            {
                float y = Mathf.PerlinNoise(x * factor, z * factor) * 2f;
                vertecies[index] = new Vector3(x, y, z);
                index++;
            }
        }

        triangles = new int[x_size * z_size * 6];

        for (int z = 0, vert = 0, tris = 0; z < z_size; z++)
        {
            for (int x = 0; x < x_size; x++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + x_size + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + x_size + 1;
                triangles[tris + 5] = vert + x_size + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertecies;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < array_size; i++)
        {
            Gizmos.DrawSphere(vertecies[i], 0.1f);
        }
    }
}
