using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class MissileHitSomething : CatchMissile
{
    abstract protected Vector3Int GetPositionOfTile(Tilemap t, ContactPoint2D contactPoint);
    WaitForSeconds interval = new WaitForSeconds(0.2f);
    RuleTile explosionTile;


    protected void PutMissileToPool()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.parent = missilePool.transform;
        missileContainer.PutToPool(this.gameObject);
        explosionTile = Resources.Load<RuleTile>("ExplosionTile");

    }

    protected Vector3Int DestroyHitItemAndGetHitTilePosition(Collision2D collision)
    {
        Tilemap t = collision.collider.GetComponent<Tilemap>();
        ContactPoint2D contactPoint = collision.GetContact(0);
        Vector3Int position = GetPositionOfTile(t, contactPoint);
        PutMissileToPool();
        t.SetTile(position, null);
        return position;
    }
  protected  IEnumerator CreateExplosionTile(Collision2D collision, Vector3Int position)
    {
        Tilemap t = collision.collider.GetComponent<Tilemap>();
        t.SetTile(position, explosionTile);
        yield return interval;
        t.SetTile(position, null);
    }
}
