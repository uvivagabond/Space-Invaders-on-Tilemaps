using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class EndGame : State
{
    public override void NextState(StateManager sm)
    {
        if (sm.StartNewGame)
        {
            ChangeState(sm, new PreparationOfInvasion());
        }
    }

    public override void OnStateEnter(StateManager sm)
    {
        sm.panels.end.SetActive(true);
        sm.levelManager.ResetToFirstLevel();
    }

    public override void OnStateExit(StateManager sm)
    {
        sm.panels.end.SetActive(false);
        sm.starshipInfo.endurance.ResetLives();
        sm.StartNewGame = false;
        sm.ships.Clear();
        sm.EnemyReachStarShip = false;
    }
}
