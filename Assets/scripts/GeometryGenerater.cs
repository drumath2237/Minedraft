using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryGenerater : MonoBehaviour
{
    [SerializeField]
    int GEO_WIDTH = 20;

    [SerializeField]
    int GEO_LENGTH = 20;

    [SerializeField]
    int GEO_HEIGHT = 20;

    [SerializeField]
    int OSEAN_HEIGHT = 8;

    [SerializeField]
    int SEED = 44;

    [SerializeField]
    float PerlinScale = 20.0f;

    [SerializeField]
    bool canChangeGeo = true;

    // Start is called before the first frame update
    void Start()
    {
        createGeometry();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canChangeGeo)
        {
            deleteAllMineBlocks();
            createGeometry();
        }
    }


    void createGeometry()
    {
        for(int x=-GEO_WIDTH; x<=GEO_WIDTH; x++)
        {
            for(int y=-GEO_LENGTH; y<=GEO_LENGTH; y++)
            {
                createBlockByPerlinNoise(x, y);
            }
        }
    }

    void createBlockByPerlinNoise(int x, int y)
    {
        float x_ = (float)x / PerlinScale + SEED;
        float y_ = (float)y / PerlinScale + SEED;

        int h = (int)(Mathf.PerlinNoise(x_, y_) * GEO_HEIGHT);
        if (h < OSEAN_HEIGHT)
        {
            for (int i = 0; i <= h; i++)
            {
                BlockManager.createBlock(BlockTypes.Sand , new Vector3(x, i, y), transform);
            }

            for (int i = h + 1; i <= OSEAN_HEIGHT; i++)
            {
                BlockManager.createBlock(BlockTypes.Water , new Vector3(x, i, y), transform);
            }
        }
        else if(h>OSEAN_HEIGHT)
        {
            for(int i=0;i <=OSEAN_HEIGHT; i++)
            {
                BlockManager.createBlock(BlockTypes.Sand , new Vector3(x, i, y), transform);
            }

            for(int i=OSEAN_HEIGHT+1; i<h; i++)
            {
                BlockManager.createBlock(BlockTypes.Ground , new Vector3(x, i, y), transform);
            }

            BlockManager.createBlock(BlockTypes.GroundWithGrass , new Vector3(x, h, y), transform);

            if(Random.Range(0, 1.0f) < 0.3)
            {
                BlockManager.createBlock(BlockTypes.GrassObject, new Vector3(x, h + 1, y), transform);
            }
        }
        else
        {
            for (int i = 0; i <= h; i++)
            {
                BlockManager.createBlock(BlockTypes.Sand , new Vector3(x, i, y), transform);
            }
        }
    }

    void deleteAllMineBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("MineBlock");
        foreach(var clone in blocks)
        {
            Destroy(clone);
        }
    }
}
