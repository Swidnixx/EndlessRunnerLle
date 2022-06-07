using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Battery : Powerup
{
    [Range(0, 1)]
    public float speedBoost = 0.1f;
}
