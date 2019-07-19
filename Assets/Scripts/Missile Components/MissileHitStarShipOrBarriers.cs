using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MissileHitStarShipOrBarriers : MissileHitSomething
{
    StarshipEndurance starshipEndurance;
    WaitForSeconds interval = new WaitForSeconds(0.4f);
    ExplosionSprites explosionSprites;
    override protected void Start()
    {
        base.Start();
        missileContainer = missilePool.enemyMissilePool;
        explosionSprites = Resources.Load<ExplosionSprites>("ExplosionSprites");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==IDOfLayer.Barriers)
        {
            Vector3Int position = DestroyHitItemAndGetHitTilePosition(collision);
            CoroutineManager.Instance.StartCoroutine(CreateExplosionTile(collision, position));
        }
        else
        {
            PutMissileToPool();
            collision.gameObject.GetComponent<StarshipEndurance>()?.EnemyHitStarship();
            CoroutineManager.Instance.StartCoroutine(CreateExplosionEfect(collision));
        }
      
    }

    IEnumerator CreateExplosionEfect(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);

        SpriteRenderer sr = collision.collider.GetComponent<SpriteRenderer>();
               for (int i = 0; i < explosionSprites.Sprites.Length; i++)
        {
            sr.sprite = explosionSprites.Sprites[i];
            yield return interval;
        }
        sr.sprite = null;
    }

    protected override Vector3Int GetPositionOfTile(Tilemap t, ContactPoint2D contactPoint)
    {
        return t.WorldToCell(contactPoint.point -( Vector2.up + contactPoint.normal) * 0.1f);
    }
}
