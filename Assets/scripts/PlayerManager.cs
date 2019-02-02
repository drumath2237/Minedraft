using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject posObj;

    void Start()
    {
        posObj = BlockTypes.Ground;
    }

    void Update()
    {
        playerOperationControl();
    }

    private void FixedUpdate()
    {
        playerMoveControl();
    }

    void playerMoveControl()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0, 0, 0.05f));
        if(Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, 0, -0.05f));

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(new Vector3(-1.0f, 0, 0));
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(new Vector3(1.0f, 0, 0));
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0, 1.0f, 0),Space.World);
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0, -1.0f, 0),Space.World);
    }

    void playerOperationControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray cameraRay = new Ray(transform.position, transform.forward.normalized);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                BlockManager.deleteBlockWithRay(cameraRay);
            }
            else
            {
                BlockManager.CreateBlockWithRay(posObj , cameraRay);
            }
        }
    }
}
