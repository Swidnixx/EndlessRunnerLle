using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    Transform player;
    GameManager gm;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        gm = GameManager.Instance;
    }
    private void FixedUpdate()
    {
        if(!gm.magnet.isActive)
        {
            return;
        }

        if(Vector3.Distance(transform.position, player.position) 
            <= gm.magnet.range)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                gm.magnet.coinSpeed
                );
        }
    }

}
