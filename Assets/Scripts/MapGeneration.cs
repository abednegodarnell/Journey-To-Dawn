using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    float[,] heightMap = new float[20, 20];
    
    void Start()
    {
        for(int x = 0; x < 20; x += 1)
        {
            for (int y = 0; y < 20; y += 1)
            {
                heightMap[x, y] = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
            }
        }

        Debug.Log(heightMap[5, 5]);
    }
}