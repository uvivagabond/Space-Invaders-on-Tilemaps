using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NumberOfEnemiesInColumns", menuName = "2D Utilities/Number of enemies in columns")]
public class NumberOfEnemiesInColumns : ScriptableObject
{
   public int[] columns = new int[11];
    public List<int> availableColumns = new List<int>();

    public int this[int i]
    {
        get { return columns[i]; }
        set
        {
            if (value > 0)
            {
                columns[i] = value;
            }
            else
                columns[i] = 0;
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = 5;
        }
    }

    public void DecreaseEnemyCount(int columnIndex)
    {
        columns[columnIndex] = columns[columnIndex] - 1;
        GetAvailableColumns();
    }

    public void GetAvailableColumns()
    {
        availableColumns.Clear();

        for (int i = 0; i < columns.Length; i++)
        {
            if (columns[i] > 0)
            {
                availableColumns.Add(i);
            }
        }
    }

    private void OnEnable()
    {
     Initialize();
        GetAvailableColumns();
    }
    private void OnDisable()
    {
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = 1;
        }
    }
}
