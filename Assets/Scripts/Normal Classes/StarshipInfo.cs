using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public struct StarshipInfo
{
    public SpriteRenderer renderer;
    public Sprite baseSprite;
    public Collider2D collider;
    public StarshipEndurance endurance;
    public Transform transform;
    public StarShipDrive starShipDrive;
}
[System.Serializable]
public struct EnemyshipInfo
{
    public Tilemap tilemap;

}