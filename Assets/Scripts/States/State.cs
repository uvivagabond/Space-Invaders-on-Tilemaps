using UnityEngine;

public abstract class State
{
    public abstract void NextState(StateManager sm);

    public virtual void OnStateEnter(StateManager sm) { }
    public virtual void OnStateExit(StateManager sm) { }


    protected static void ChangeState(StateManager sm, State newState)
    {
        if (sm.State != null)
            sm.State.OnStateExit(sm);

        sm.State = newState;

        if (sm.State != null)
            sm.State.OnStateEnter(sm);
    }


    protected static void AreShipsMoving(StateManager sm, bool areShipsActive)
    {
        sm.FindBaseShipsScripts();
        foreach (var item in sm.ships)
        {
            item.enabled = areShipsActive;
        }
    }

 
}
