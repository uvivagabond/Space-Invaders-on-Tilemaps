using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class MissilePool : MonoBehaviour
{
    public PoolingManager<GameObject> enemyMissilePool;
    public PoolingManager<GameObject> playerMissilePool;

    public GameObject missileForStarship;
    public GameObject missileForEnemies;

    void Start()
    {
        playerMissilePool = new PoolingManager<GameObject>(CreatePoolObjectForStarShip);
        enemyMissilePool = new PoolingManager<GameObject>(CreatePoolObjectForEnemyShip);

        missileForStarship = Resources.Load<GameObject>("StarShipMissile");
        missileForEnemies = Resources.Load<GameObject>("EnemyShipMissile");
    }

    public GameObject CreatePoolObjectForStarShip()
    {
        return Instantiate<GameObject>(missileForStarship, Vector3.zero,Quaternion.identity);
    }
    public GameObject CreatePoolObjectForEnemyShip()
    {
        return Instantiate<GameObject>(missileForEnemies,Vector3.zero, Quaternion.identity);
    }   
}
