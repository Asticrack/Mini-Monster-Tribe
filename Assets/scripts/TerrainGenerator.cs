using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size;

    private static int TILE_SIZE = 10;

    public GameObject terrain;
    public GameObject corner;
    public GameObject barrier;
    public GameObject cell;

    // Start is called before the first frame update
    void Start()
    {
        if(size == 1)
        {
            // TODO
        }

        float startX = -size / 2.0f * TILE_SIZE;
        float startZ = -size / 2.0f * TILE_SIZE;

        float up = size - 1;
        float down = 0;
        float left = 0;
        float right = size - 1;

        for (int x = 0; x < size; x++)
        {
            for(int z = 0; z < size; z++)
            {
                if(x == left && z == up)
                {
                    Instantiate(corner, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.Euler(0, 180, 0));
                } else if(x == left && z == down)
                {
                    Instantiate(corner, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.Euler(0, 90, 0));
                } else if(x == right && z == up)
                {
                    Instantiate(corner, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.Euler(0, -90, 0));
                } else if(x == right && z == down)
                {
                    Instantiate(corner, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.identity);
                } else if(x == right)
                {
                    Instantiate(barrier, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.Euler(0, -90, 0));
                } else if(x == left)
                {
                    Instantiate(barrier, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.Euler(0, 90, 0));
                } else if(z == up)
                {
                    Instantiate(barrier, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.Euler(0, 180, 0));
                } else if(z == down)
                {
                    Instantiate(barrier, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.identity);
                } else {
                    Instantiate(terrain, new Vector3(startX + x * TILE_SIZE, 0, startZ + z * TILE_SIZE), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
