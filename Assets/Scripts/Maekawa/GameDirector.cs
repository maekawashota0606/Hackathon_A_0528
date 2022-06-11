using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : SingletonMonoBehaviour<GameDirector>
{
    [SerializeField]
    private GameObject _enemyPrefab = null;
    [SerializeField]
    private GameObject _itemPrefab = null;
    [SerializeField]
    private GameObject _rootEnemies = null;
    [SerializeField]
    private GameObject _rootItems = null;
    private const int _MAX_FLOOR = 5;
    private const string _PLAYERS_TAG = "Player";
    public const int WIDTH = 99;
    public const int HEIGHT = 99;
    private Player _player = null;
    private List<Enemy> _floorEnemies = new List<Enemy>(100);
    private List<ItemBase> _items = new List<ItemBase>();
    private int _floor = 0;
    private bool _isGameOver = false;
    private bool _isMovedPlayer = false;

    private void Start()
    {
        Init();
        FloorInit();
    }

    private void Update()
    {
        if (_isGameOver)
            return;

        if (_isMovedPlayer)
            EnemiesMove();
        else
            _player.PlayerUpdate();
    }

    private void EnemiesMove()
    {
        Debug.Log("EnemiesTurn");
        _isMovedPlayer = false;
        foreach(Enemy enemy in _floorEnemies)
        {
            enemy.Action();
        }
    }

    public void SetIsMovedPleyer(bool isMoved)
    {
        _isMovedPlayer = isMoved;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public Enemy GetEnemy(Vector2Int pos)
    {
        foreach(Enemy enemy in _floorEnemies)
        {
            if (enemy.GetPosition() == pos)
                return enemy;
        }
        return null;
    }

    public ItemBase GetItem(Vector2Int pos)
    {
        foreach(ItemBase item in _items)
        {
            if (item.GetPosition() == pos)
                return item;
        }
        return null;
    }

    private void Init()
    {
        _player = GameObject.FindWithTag(_PLAYERS_TAG).GetComponent<Player>();
        _player.Init();
        MaskController.Instance.Init();
        UIManager.Instance.SetLevelText(_player.GetLevel());
        UIManager.Instance.SetHPText(_player.GetHP(), _player.GetMaxHP());
    }

    private void FloorInit()
    {
        _floor++;
        UIManager.Instance.SetFloorText(_floor);

        //éGÇ…ÉVÅ[ÉhílÇó^Ç¶ÇÈ
        RandomDungeonWithBluePrint.MapGenerator.Instance.GenerateMap(Time.frameCount);

        Vector2Int pos = new Vector2Int();

        while (true)
        {
            pos.x = Random.Range(0, WIDTH);
            pos.y = Random.Range(0, HEIGHT);
            _player.SetPlayerPos(pos);

            if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(_player.GetPlayerPos()) == RandomDungeonWithBluePrint.Map.TileType.Floor)
                break;
        }

        int enemyNum = 5;
        for (int i = 0; i < _floorEnemies.Count; i++)
        {
            Destroy(_floorEnemies[i].gameObject);
        }
        _floorEnemies.Clear();

        for (int i = 0; i < enemyNum; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab).GetComponent<Enemy>();
            enemy.transform.SetParent(_rootEnemies.transform);
            while (true)
            {
                pos.x = Random.Range(0, WIDTH);
                pos.y = Random.Range(0, HEIGHT);

                if (IsHItPlayer(pos) || IsHitEnemies(pos) || IshitWall(pos))
                    continue;

                if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(pos) == RandomDungeonWithBluePrint.Map.TileType.Floor)
                {
                    enemy.Init();
                    enemy.SetPosition(pos);
                    _floorEnemies.Add(enemy);
                    break;
                }
            }

        }

        while (true)
        {
            pos.x = Random.Range(0, WIDTH);
            pos.y = Random.Range(0, HEIGHT);

            if (IsHItPlayer(pos))
                continue;

            if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(pos) == RandomDungeonWithBluePrint.Map.TileType.Floor)
            {
                RandomDungeonWithBluePrint.Map.Instance.SetMapData(RandomDungeonWithBluePrint.Map.TileType.Stairs, pos);
                //Debug.Log(pos);
                break;
            }
        }


        int itemNum = 5;
        for (int i = 0; i < _items.Count; i++)
        {
            Destroy(_items[i].gameObject);
        }
        _items.Clear();

        for (int i = 0; i < itemNum; i++)
        {
            ItemBase item = Instantiate(_itemPrefab).GetComponent<ItemBase>();
            item.transform.SetParent(_rootItems.transform);

            while (true)
            {
                pos.x = Random.Range(0, WIDTH);
                pos.y = Random.Range(0, HEIGHT);

                if (IsHItPlayer(pos) || IsHitItems(pos))
                    continue;

                if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(pos) == RandomDungeonWithBluePrint.Map.TileType.Floor)
                {
                    item.SetPosition(pos);
                    _items.Add(item);
                    break;
                }
            }
        }
    }

    public void NextFloor()
    {
        if (_MAX_FLOOR < _floor)
            Debug.Log("Clear");
        else
            FloorInit();
    }

    public bool IsHItPlayer(Vector2Int pos)
    {
        if (_player.GetPlayerPos() == pos)
            return true;
        else
            return false;
    }

    public bool IshitWall(Vector2Int pos)
    {
        return RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(pos) == RandomDungeonWithBluePrint.Map.TileType.Wall;
    }

    public bool IsHitEnemies(Vector2Int pos)
    {
        foreach(Enemy enemy in _floorEnemies)
        {
            if (enemy.GetPosition() == pos)
                return true;
        }
        return false;
    }

    public bool IsHitItems(Vector2Int pos)
    {
        foreach(ItemBase item in _items)
        {
            if (item.GetPosition() == pos)
                return true;
        }
        return false;
    }

    public void GameOver()
    {
        //
        _isGameOver = true;
        SceneController.Instance.sceneChange("TitleScene");
        Debug.Log("GameOver");
    }

    public void DeleteEnemy(Enemy enemy)
    {
        _floorEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    public void DeleteItem(ItemBase item)
    {
        _items.Remove(item);
        Destroy(item.gameObject);
    }
}
