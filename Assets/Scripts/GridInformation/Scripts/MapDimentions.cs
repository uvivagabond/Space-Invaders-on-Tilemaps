using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New MapDimentions", menuName = "2D Utilities/Map Dimentions")]
public class MapDimentions:ScriptableObject
{
    public int width = 0;
    public int height = 0;

    //public MapDimentions(int width, int heigt)
    //{
    //    this.width = width;
    //    this.height = heigt;
    //}
}
