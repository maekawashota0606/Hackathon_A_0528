using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private const int _MAX_FLOOR = 5;
    private const string _PLAYERS_TAG = "Player";
    public const int WIDTH = 99;
    public const int HEIGHT = 99;
    private Player _player = null;
    private int _floor = 1;
    // private List<Enemy>

    void Start()
    {
        Init();
        FloorInit();
    }

    void Update()
    {
        
    }

    private void Init()
    {
        _player = GameObject.FindWithTag(_PLAYERS_TAG).GetComponent<Player>();
    }

    private void FloorInit()
    {
        //éGÇ…ÉVÅ[ÉhílÇó^Ç¶ÇÈ
        RandomDungeonWithBluePrint.MapGenerator.Instance.GenerateMap(Time.frameCount);

        Vector2Int pos = new Vector2Int();
        while(true)
        {
            pos.x = Random.Range(0, WIDTH);
            pos.y = Random.Range(0, HEIGHT);
            _player.SetPlayerPos(pos);

            Debug.Log(RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(_player.GetPositivePlayerPos()));
            if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(_player.GetPositivePlayerPos()) == RandomDungeonWithBluePrint.Map.TileType.Floor)
                break;
        }
    }
}
