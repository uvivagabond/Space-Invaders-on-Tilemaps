using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : State
{
    float timer = 0;
    public override void NextState(StateManager sm)
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            ChangeState(sm, new PreparationOfInvasion());
        }
    }

    public override void OnStateEnter(StateManager sm)
    {
        sm.panels.win.SetActive(true);
        sm.levelManager.LoadActualLevel();
    }

    public override void OnStateExit(StateManager sm)
    {
        sm.panels.win.SetActive(false);
    }
}