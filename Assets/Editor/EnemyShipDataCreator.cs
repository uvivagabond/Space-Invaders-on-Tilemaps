using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EnemyShipDataCreator : EditorWindow
{
    public EnemyStatistics enemyData;
    string path;
    string enemyName="Default Name";
    float attackRate = 1f;
    int damage = 1;

    [MenuItem("Space Invaders /EnemyShip Data Creator")]
    static void Init()
    {
        EnemyShipDataCreator window = (EnemyShipDataCreator)EditorWindow.GetWindow(typeof(EnemyShipDataCreator));
        window.Show();
    }

    void OnGUI()
    {
        if (enemyData == null)
        {
            enemyData = new EnemyStatistics();
        }
        GUI.skin.textField.wordWrap = true;
        enemyData.enemyName = EditorGUILayout.TextField("Nazwa przeciwnika", enemyData.enemyName);

        enemyData.damage = EditorGUILayout.IntField(enemyData.damage);
        enemyData.attackRate = EditorGUILayout.FloatField(enemyData.attackRate);

        GUILayout.BeginHorizontal();
        bool save = GUILayout.Button("Zapisz");
        bool clear = GUILayout.Button("Wyczyść okno");
        bool load = GUILayout.Button("Załaduj");

        if (save)
        {
            SetPath();
            CreateDirectoryIfDontExist();
            DataManager.SaveToJson<EnemyStatistics>(path, enemyData);
        }
        else if (load)
        {
            SetPath();
            enemyData = DataManager.LoadFromJson<EnemyStatistics>(path);
        }
        else if (clear)
        {
            SetPath();
            enemyData.enemyName = "";
            enemyData.damage = 0;
            enemyData.attackRate = 0f;
            GUIUtility.keyboardControl = 0;
        }
        GUILayout.EndHorizontal();
    }

    private void SetPath()
    {
        path = Application.streamingAssetsPath + "/" + enemyData.enemyName + ".json";
    }

    private void CreateDirectoryIfDontExist()
    {
        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
        {
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
        }
    }
}
