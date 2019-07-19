using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MissileHitEnemy : MissileHitSomething
{
    NumberOfEnemiesInColumns numberOfEnemiesInColumns;

    override protected void Start()
    {
        base.Start();
        missileContainer = missilePool.playerMissilePool;
        numberOfEnemiesInColumns = Resources.Load<NumberOfEnemiesInColumns>("NumberOfEnemiesInColumns");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3Int position = DestroyHitItemAndGetHitTilePosition(collision);
        CoroutineManager.Instance.StartCoroutine(CreateExplosionTile(collision, position));
        if (collision.gameObject.layer==IDOfLayer.Enemies)
        {
            numberOfEnemiesInColumns.DecreaseEnemyCount(position.x);
        }
    }

    override protected Vector3Int GetPositionOfTile(Tilemap t, ContactPoint2D contactPoint)
    {
        return t.WorldToCell(contactPoint.point + (Vector2.up - contactPoint.normal) * 0.1f);
    }

}
