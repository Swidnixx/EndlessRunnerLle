using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public int level = 1;
    public int upgradeCost = 100;

    public bool isActive = false;
    public float duration = 3;
}