using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    int[,] grid = new int[100, 100];
    
    public int MapGenerator(int firstGrid, int secondGrid)
    {
        grid = Random.Range(0, 2);
        return grid;

    }

    public int SpawnGrid(int grid1, int grit2)
    {
        for (int grid1 = 0; grid2 = 1;)
        {
            for (grid1 == 0)
            {
                Console.WriteLine("Spawn floor");
                Instantiate(Floor);
            }

            for (grid2 == 1)
            {
                Console.WriteLine("Spawn wall");
                Instantiate(Wall);     
            }
                
        }
    }
}
