using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform tile1;
    public Transform tile2;

    public float speed = 0.1f;
    private void FixedUpdate()
    {
        tile1.position -= new Vector3(speed, 0, 0);
        tile2.position -= new Vector3(speed, 0, 0);

        if(tile2.position.x <= 0)
        {
            tile1.position = tile2.position + new Vector3(16, 0, 0);

            Transform tmp = tile1;
            tile1 = tile2;
            tile2 = tmp;
        }
    }

}
