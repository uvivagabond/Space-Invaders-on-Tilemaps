using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Intro : State
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
        sm.panels.intro.SetActive(true);
        AreShipsMoving(sm, false);
    }

    public override void OnStateExit(StateManager sm)
    {
        sm.panels.intro.SetActive(false);
        sm.StartNewGame = false;
        sm.FindBaseShipsScripts();
    }

}
