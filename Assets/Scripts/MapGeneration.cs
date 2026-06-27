
using UnityEngine;


public class MapGeneration : MonoBehaviour
{
    public GameObject Grassland;
    public Texture2D Grass;
    float[,] heightMap = new float[20, 20]; 
    
    void Start()
    {
        Vector3[] vertices = new Vector3[20 * 20];
        Vector2[] uvs = new Vector2[20 * 20];
        Debug.Log(vertices.Length);
        

        for(int x = 0; x < 20; x += 1)
        {
            for (int y = 0; y < 20; y += 1)
            {
                heightMap[x, y] = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
                int index = x * 20 + y;
                vertices[index] = new Vector3(x, heightMap[x, y], y);
                uvs[index] = new Vector2(x / 19f, y / 19f);
            }
        }

        int[] triangles = new int[19 * 19 * 2 * 3];
            int t = 0;

            for(int x = 0; x < 19; x++)
            {
                for(int y = 0; y < 19; y++)
                {
                    int topLeft = x * 20 + y;
                    int topRight = (x + 1) * 20 + y;
                    int bottomLeft = x * 20 + (y+ 1);
                    int bottomRight = (x + 1) * 20 + (y+1);

                    triangles[t++] = topLeft;
                    triangles[t++] = bottomLeft;
                    triangles[t++] = topRight;
                    
                    triangles[t++] = bottomLeft;
                    triangles[t++] = bottomRight;
                    triangles[t++] = topRight;
                } 
            }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uvs;

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Standard"));
        mf.mesh = mesh;
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        mc.sharedMesh = mesh;
        mr.material.mainTexture = 
        
        Debug.Log(heightMap[5, 5]);
        Debug.Log(vertices[0]);
        Debug.Log(t);
        SpawnTiles();

    }

    void SpawnTiles()
    {
        for(int x = 0; x < 20; x += 1)
        {
            for (int y = 0; y < 20; y += 1)
            {
                Vector3 pos = new Vector3(x, heightMap[x, y] * 8, y);
            }
        }
    }
}