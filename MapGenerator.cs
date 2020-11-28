using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;

    [Range(0,100)]
    public int randomFillPercent;
    int [, ] map;

    public string seed;
    public bool useRandomSeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GeneratorMap();
    }

    void GeneratorMap()
    {
        map = new int[width, height];
        RandomFillMap();
        
    }
    // Update is called once per frame
    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = pseudoRandom.Next(0,100) < randomFillPercent ? 1 : 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1 ? Color.black : Color.white);
                    Vector3 position = new Vector3(-width / 2 + x + 0.5f, -height + y + 0.5f,0);
                    Gizmos.DrawCube(position, Vector3.one);
                }
            }
        }
    }

}
