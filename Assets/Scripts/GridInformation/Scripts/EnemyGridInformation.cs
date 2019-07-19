using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyGridInformation : GridInformation
{
   string enemy = "enemy";
    MapDimentions swarmDimentions;

    private void Start()
    {
        swarmDimentions = Resources.Load<MapDimentions>("EnemySwarmDimentions");
    }

    public void IsThereEnemy(Vector3Int position, bool exist)
    {
        this.SetPositionProperty(position, enemy, exist);
    }

    
    
}
