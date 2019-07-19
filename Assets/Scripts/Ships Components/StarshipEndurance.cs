using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipEndurance : MonoBehaviour
{
    int lives = 3;
    int HP = 100;

    public bool WasPlayerHit { get; set; }
    public int Lives { get => lives; private set => lives = value; }

    public void EnemyHitStarship() {
        WasPlayerHit = true;
        Lives--;
       }

    public void ResetHP() { HP = 100; }
    public void ResetLives() { Lives = 2;}
}
