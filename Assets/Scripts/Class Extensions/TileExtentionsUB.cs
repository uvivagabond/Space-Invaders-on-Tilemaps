using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileExtentionsUB 
{
    public static void SetPosition(this Tile t, Vector3 position)
    {
        Matrix4x4 temp = t.transform;
        t.transform = Matrix4x4.TRS(position, temp.rotation, temp.lossyScale);
    }

    public static void SetRotation(this Tile t, Quaternion rotation)
    {
        Matrix4x4 temp = t.transform;
        t.transform = Matrix4x4.TRS((Vector3)temp.GetColumn(4), rotation, temp.lossyScale);
    }

    public static void SetPositionAndRotation(this Tile t, Vector3 position, Quaternion rotation)
    {
        Matrix4x4 temp = t.transform;
        t.transform = Matrix4x4.TRS(position, rotation, temp.lossyScale);
    }

    public static void SetScale(this Tile t, Vector3 scale)
    {
        Matrix4x4 temp = t.transform;
        t.transform = Matrix4x4.TRS((Vector3)temp.GetColumn(4), temp.rotation, scale);
    }

    public static void TRS(this Tile t, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Matrix4x4 temp = t.transform;
        t.transform = Matrix4x4.TRS(position, rotation, temp.lossyScale);
    }

    public static void ResetTRS(this Tile t)
    {
        t.transform = Matrix4x4.identity;
    }
}
