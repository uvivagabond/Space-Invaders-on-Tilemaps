using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShip : State
{
    float timer = 0;
    public override void NextState(StateManager sm)
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            ChangeState(sm, new PlayGame());
        }
    }

    public override void OnStateEnter(StateManager sm)
    {
        AreShipsMoving(sm, false);
    }
}
