using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyReachStarShip : MonoBehaviour
{
    public UnityEvent PlayerLose;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer==IDOfLayer.Enemies)
        {
            PlayerLose?.Invoke();
        }
    }
}
