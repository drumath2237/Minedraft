using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockTypes
{
    public static GameObject Ground { get => Resources.Load("blocks/block_ground") as GameObject; }
    public static GameObject Grass { get => Resources.Load("blocks/block_grass") as GameObject; }
    public static GameObject Sand { get => Resources.Load("blocks/block_sand") as GameObject; }
    public static GameObject Water { get => Resources.Load("blocks/block_water") as GameObject; }
    public static GameObject GroundWithGrass { get => Resources.Load("blocks/block_ground_with_grass") as GameObject; }

    public static GameObject GrassObject { get => Resources.Load("Objects/obj_grass") as GameObject; }
}
