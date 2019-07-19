using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New ExplosionSprites", menuName = "2D Utilities/ExplosionSprites")]
public class ExplosionSprites : ScriptableObject
{
    public Sprite[] Sprites;
}
