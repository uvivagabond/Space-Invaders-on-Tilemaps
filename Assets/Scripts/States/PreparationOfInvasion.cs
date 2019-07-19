using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class PreparationOfInvasion : State
{
    float timer = 0;
    public override void NextState(StateManager sm)
    {    
        timer += Time.deltaTime;
        if (timer>2)
        {
            ChangeState(sm, new PlayGame());
        }
    }

    public override void OnStateEnter(StateManager sm)
    {
        sm.FindBaseShipsScripts();
        AreShipsMoving(sm,false);
        sm.starshipInfo.renderer.sprite = sm.starshipInfo.baseSprite;
        sm.starshipInfo.collider.enabled = true;
        sm.starshipInfo.starShipDrive.ReturnToStartPosition();
        sm.starshipInfo.endurance.ResetHP();
        sm.panels.pause.SetActive(true);
    }

    public override void OnStateExit(StateManager sm)
    {
          sm.panels.pause.SetActive(false);
    }

}
