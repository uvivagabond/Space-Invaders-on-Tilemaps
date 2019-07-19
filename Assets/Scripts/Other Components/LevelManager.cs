using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-200)]
public class LevelManager : MonoBehaviour
{
    int getActualLevelNumber = 1;

    private void Awake()
    {
        LoadFirstLevel();
    }

    public void LoadFirstLevel()
    {
        LoadChosenLevel(1);
    }
    public void ResetToFirstLevel()
    {
        getActualLevelNumber = 1;
    }
    public void LoadChosenLevel(int numberOfLevel)
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
        GameObject level = Instantiate<GameObject>(Resources.Load<GameObject>(numberOfLevel.ToString()), transform, false);
    }

    public void LoadActualLevel()
    {
        getActualLevelNumber += 1;

        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
        GameObject level = Instantiate<GameObject>(Resources.Load<GameObject>(getActualLevelNumber.ToString()), transform, false);
    }
}
