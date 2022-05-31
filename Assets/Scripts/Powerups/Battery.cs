using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Battery : ScriptableObject
{
    public bool isActive = false;
    public float duration = 3;
    [Range(0, 1)]
    public float speedBoost = 0.1f;
}
