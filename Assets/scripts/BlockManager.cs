using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockManager
{
    public static void CreateBlockWithRay(GameObject block, Ray ray)
    {
        if (block.tag != "MineBlock")
            return;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "MineBlock")
            {
                Vector3 p = hit.collider.gameObject.transform.position + hit.normal;
                createBlock(block, p);
            }
        }
    }

    public static void createBlock(GameObject block, Vector3 pos)
    {
        Object.Instantiate(block, pos, new Quaternion());
    }

    public static void createBlock(GameObject block, Vector3 pos, Transform parent)
    {
        Object.Instantiate(block, pos, new Quaternion(), parent);
    }

    public static void deleteBlockWithRay(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.tag == "MineBlock" || hitObject.tag == "MineObject")
            {
                GameObject breakEffect = Resources.Load("effects/breakEffect") as GameObject;
                Object.Destroy(Object.Instantiate(breakEffect, hitObject.transform.position, hitObject.transform.rotation), 3.0f);
                breakEffect.GetComponent<ParticleSystem>().Play();
                Object.Destroy(hitObject);

            }
        }
    }

}
