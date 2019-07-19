using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.ParticleSystem;

public class EnemyShipArmament : VehicleArmament
{
    Tilemap tilemap;
    NumberOfEnemiesInColumns numberOfEnemiesInColumns;
    List<int> columnsWithSomeTiles = new List<int>();
    public MinMaxCurve intervalOfRandomBreaksBetweenShots = new MinMaxCurve(0.5f, 1f);

    public override void Start()
    {
        base.Start();
        missileContainer = missilePool.enemyMissilePool;
        tilemap = GetComponent<Tilemap>();
        numberOfEnemiesInColumns = Resources.Load<NumberOfEnemiesInColumns>("NumberOfEnemiesInColumns");
    }

    float timer = 0;

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = Random.Range(intervalOfRandomBreaksBetweenShots.constantMin, intervalOfRandomBreaksBetweenShots.constantMax);
            Shoot();
        }
    }

    Vector3 DrawWhoShoots()
    {
        int numberOfEnemyColumns = numberOfEnemiesInColumns.availableColumns.Count;
        int randomArrayIndex = Random.Range(0, numberOfEnemyColumns);
        int numberOfColumn = numberOfEnemiesInColumns.availableColumns[randomArrayIndex];
        if (numberOfEnemiesInColumns[numberOfColumn] > 0)
        {
            return tilemap.GetCenterOfTileInWorldSpace(GetFirstBottomTilePosition(numberOfColumn));
        }
        return Vector3.zero;
    }

    Vector3Int GetFirstBottomTilePosition(int columnIndex)
    {
        int enemyRowsCount = 5;
        for (int i = 0; i < enemyRowsCount; i++)
        {
            Vector3Int position = new Vector3Int(columnIndex, i, 0);
            if (tilemap.HasTile(position))
            {
                return position;
            }
        }
        return Vector3Int.zero;
    }

    public override void Shoot()
    {
        GameObject missile = base.InitializeMissile(new Vector3(0, -missileSpeed, 0));
        missile.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        missile.transform.position = DrawWhoShoots();
    }
}
