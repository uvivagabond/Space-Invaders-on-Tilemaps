using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapExtentionsUB {
    
    public static bool HasAnyTile(this Tilemap tilemap)
    {
        foreach (var item in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(item))
            {
                return true;
            }           
        }
        return false;
    }

    public static int HowManyTilesAreInColumn(this Tilemap tilemap, int columnIndex, int minY, int maxY)
    {
        int tileCount = 0;
        for (int i = minY; i < maxY-minY; i++)
        {
            if (tilemap.HasTile(new Vector3Int(i, columnIndex, 0)))
            {
                tileCount++;
            }
        }
        return tileCount;
    }

    public static bool IsThereAnyTilesInColumn(this Tilemap tilemap, int columnNumber, int minY, int maxY)
    {     
        for (int i = minY; i < maxY - minY; i++)
        {
            if (!tilemap.HasTile(new Vector3Int(i, columnNumber, 0)))
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsTileOfType(this Tilemap tilemap, Vector3Int position, TileBase tile)
    {    
        return tilemap.HasTile(position) && tilemap.GetTile<TileBase>(position) == tile;
    }

    /// <summary>
    /// Removes tile at position (sets it null)
    /// </summary>
    /// <param name="positionOfCell"></param>
    public static void RemoveTileAtPosition(this Tilemap t, Vector3Int positionOfCell)
    {
        t.SetTile(positionOfCell, null);
    }


    /// <summary>
    /// Method to change positions in grid space to positions of centers of grid in world space
    /// </summary>
    /// <param name="listOfPositionsOfCells"> List of positions in grid space</param>
    public static List<Vector3> GetCentersOfTilesInWorldSpace(this Tilemap t, List<Vector3Int> listOfPositionsOfCells)
    {
        int lenght = listOfPositionsOfCells.Count;
        List<Vector3> vlist = new List<Vector3>(lenght);
        for (int i = 0; i < lenght; i++)
        {
            vlist[i] = t.GetCenterOfTileInWorldSpace(listOfPositionsOfCells[i]);
        }
        return vlist;
    }


    /// <summary>
    /// Method to change positions in grid space to positions of centers of grid in world space
    /// </summary>
    /// <param name="arrayOfPositionsOfCells">Array of positions in grid space</param>  
    public static Vector3[] GetCentersOfTilesInWorldSpace(this Tilemap t, Vector3Int[] arrayOfPositionsOfCells)
    {
        int lenght = arrayOfPositionsOfCells.Length;

        Vector3[] vArray = new Vector3[lenght];
        for (int i = 0; i < lenght; i++)
        {
            vArray[i] = t.GetCenterOfTileInWorldSpace(arrayOfPositionsOfCells[i]);
        }
        return vArray;
    }


    /// <summary>
    /// Get center of tile in world space
    /// </summary>
    /// <param name="positionOfCell"> Position of cell in grid space </param>
    /// <returns></returns>
    public static Vector3 GetCenterOfTileInWorldSpace(this Tilemap t, Vector3Int positionOfCell)
    {
        Grid grid = t.layoutGrid;        
        Vector3 localPosition = grid.CellToLocalInterpolated(new Vector3(positionOfCell.x + 0.5f, positionOfCell.y + 0.5f, positionOfCell.z + 0.5f));
        Vector3 worldPosition = grid.LocalToWorld(localPosition);
        return worldPosition + t.transform.position + grid.transform.position;
    }


    /// <summary>
    /// Are tiles neighboring?
    /// </summary>
    /// <param name="lhs"> First position</param>
    /// <param name="rhs"> Second position</param>
    /// <returns></returns>
    public static bool AreNeighboring(this Tilemap t, Vector3Int lhs, Vector3Int rhs)
    {
        if (lhs.x == rhs.x && lhs.y == rhs.y)
        {
            return false;
        }

        return ((lhs.x == rhs.x || lhs.x == rhs.x - 1 || lhs.x == rhs.x + 1) &&
                (lhs.y == rhs.y || lhs.y == rhs.y - 1 || lhs.y == rhs.y + 1))
                ? true : false;
    }
}
