using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform tile1;
    public Transform tile2;

    public Transform[] allTiles;

    private void FixedUpdate()
    {
        float speed = GameManager.Instance.worldScrollingSpeed;

        tile1.position -= new Vector3(speed, 0, 0);
        tile2.position -= new Vector3(speed, 0, 0);

        if(tile2.position.x <= 0)
        {
            Destroy(tile1.gameObject);
            Vector3 position = tile2.position + new Vector3(16, 0, 0);
            Transform tileToCreate = allTiles[Random.Range(0, allTiles.Length)];
            Transform newTile = Instantiate(tileToCreate, position, Quaternion.identity);

            tile1 = tile2;
            tile2 = newTile;
        }
    }

}
