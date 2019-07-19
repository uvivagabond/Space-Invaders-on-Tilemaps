using System.Collections;
using UnityEngine;

class PlayGame : State
{
    float timer = 0;
    public override void NextState(StateManager sm)
    {
        if (DidPlayerLostOneLive(sm))
        {
            sm.starshipInfo.collider.enabled = false;
            timer += Time.deltaTime;
            AreShipsMoving(sm, false);

            if (timer > 2)
            {
                ChangeState(sm, new PreparationOfInvasion());
            }
        }

        if (DidPlayerWin(sm))
        {
            timer += Time.deltaTime;
            AreShipsMoving(sm, false);

            if (timer > 1)
            {
                AreShipsMoving(sm, false);
                ChangeState(sm, new WinGame());
            }
        }
        else if (DidPlayerLose(sm))
        {
            timer += Time.deltaTime;
            AreShipsMoving(sm, false);
            if (timer > 1)
            {
                ChangeState(sm, new EndGame());
            }
        }
    }

    public override void OnStateEnter(StateManager sm)
    {
        AreShipsMoving(sm, true);
    }

    public override void OnStateExit(StateManager sm)
    {
        sm.starshipInfo.endurance.WasPlayerHit = false;
        sm.starshipInfo.renderer.sprite = sm.starshipInfo.baseSprite;
        sm.numberOfEnemiesInColumns.Initialize();
        sm.numberOfEnemiesInColumns.GetAvailableColumns();
    }

    private static bool DidPlayerWin(StateManager sm)
    {
        return !sm.enemyshipInfo.tilemap.HasAnyTile() || Input.GetKey(KeyCode.P);
    }
    private static bool DidPlayerLostOneLive(StateManager sm)
    {
        return sm.starshipInfo.endurance.WasPlayerHit && sm.starshipInfo.endurance.Lives > 0;
    }

    private static bool DidPlayerLose(StateManager sm)
    {
        return sm.starshipInfo.endurance.Lives == 0 || sm.EnemyReachStarShip;
    }

 
}

