using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    int[,] grid = new int[100, 100];
    
    void GenerateGrid()
    {
        for (x = 0; x > 100; x ++ )
        {
            grid1 = Random.Range(0, 2);
            if (grid1 == 0)
            {
                Instantiate(FLoor);
            }
            else
            {
                Console.Log.Println("Spawn walls");
            }
        }
        
        for (x1 = 0; x1 > 100; x1 ++)
        {
            grid2 = Random.Range(0, 2);
            if (grid2 == 0)
            {
                Instantiate(Floor);
            }
            else
            {
                Console.Log.Println("Spawn walls");
            }
        }

        for (x2 = 0; x2 > 100; x2 ++)
        {
            grid3 = Random.Range(0, 2);
            if (grid3 == 0)
            {
                Instantiate(FLoor);
            }
            else
            {
                Console.Log.Println("Spawn walls");
            }
        }

        for (y = 0; y > 100; y++)
        {
            grid4 = Random.Range(0, 2);
            if (grid4 == 0)
            {
                Instantiate(Wall);
            }
            else
            {
                Console.Log.WriteLine("Spawn floors");
            }

        for (y1 = 0; y1 > 100; y1 ++)
            {
            
            }
    
            
        }
    }
}
