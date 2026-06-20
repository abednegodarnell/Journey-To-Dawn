using UnityEngine;


public class MapGeneration : MonoBehaviour
{
    public GameObject Grassland;
    float[,] heightMap = new float[20, 20]; 
    
    void Start()
    {
        Vector3[] vertices = new Vector3[20 * 20];
        Debug.Log(vertices.Length);

        for(int x = 0; x < 20; x += 1)
        {
            for (int y = 0; y < 20; y += 1)
            {
                heightMap[x, y] = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
            }
        }

        Debug.Log(heightMap[5, 5]);

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