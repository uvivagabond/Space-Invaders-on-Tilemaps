using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class StateManager : MonoBehaviour
{
    public MenuPanels panels;
    public bool StartNewGame { get; set; }
    public bool EnemyReachStarShip { get; set; }
    [HideInInspector]public NumberOfEnemiesInColumns numberOfEnemiesInColumns;
    public State State { get; set;}
    [HideInInspector] public List<ShipBase> ships = new List<ShipBase>(4);
    [HideInInspector] public StarshipInfo starshipInfo;
    [HideInInspector] public EnemyshipInfo enemyshipInfo;
    [HideInInspector] public LevelManager levelManager;

    void Start()
    {
        this.State = new Intro();
        numberOfEnemiesInColumns = Resources.Load<NumberOfEnemiesInColumns>("NumberOfEnemiesInColumns");
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update() {
        this.Request();
    }
    
    void Request()
    {
        this.State?.NextState(this);
    }

    #region Methods for menu buttons
  
    public void StartGame()
    {
        this.StartNewGame = true;
    }

    public void OpponentWentDown()
    {
        this.EnemyReachStarShip = true;
    }
    #endregion

 
    public void FindBaseShipsScripts()
    {
        ships.Clear();

        GameObject[] foundGameObjects = GameObject.FindGameObjectsWithTag(Tags.Ship);

        foreach (var item in foundGameObjects)
        {
            this.ships.AddRange(item.GetComponents<ShipBase>());
        }
        FindSpaceShipRendererAndStarshipEndurance();
    }

    private void FindSpaceShipRendererAndStarshipEndurance()
    {
        foreach (var item in this.ships)
        {
            if (item.gameObject.layer == IDOfLayer.Player)
            {
                this.starshipInfo.renderer = item.GetComponent<SpriteRenderer>();
                this.starshipInfo.endurance = item.GetComponent<StarshipEndurance>();
                this.starshipInfo.collider = item.GetComponent<Collider2D>();
                this.starshipInfo.baseSprite = Resources.Load<Sprite>("StarShip");
                this.starshipInfo.transform = item.GetComponent<Transform>();
                this.starshipInfo.starShipDrive = item.GetComponent<StarShipDrive>();
            }
            else
            {
                enemyshipInfo.tilemap = item.GetComponent<Tilemap>();
            }
        }
    }
}








