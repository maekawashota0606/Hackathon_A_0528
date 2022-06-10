using UnityEngine;
using UnityEngine.Tilemaps;

namespace RandomDungeonWithBluePrint
{
    public class Map : SingletonMonoBehaviour<Map>
    {
        [SerializeField] private Tilemap tilemap = null;
        [SerializeField] private Tile[] tiles = new Tile[(int)TileType.Size];
        private TileType[,] mapData = new TileType[GameDirector.WIDTH, GameDirector.HEIGHT];

        public enum TileType
        {
            None = -1,
            Floor,
            Wall,
            Stairs,
            Size
        }


        // 外部からセットすることはないかも
        public void SetMapData(TileType type, Vector2Int pos)
        {
            mapData[pos.x, pos.y] = type;
            Tile tile = tiles[(int)type];
            tilemap.SetTile(new Vector3Int(pos.x, -pos.y, 0), tile);
        }


        /// <summary>
        /// 当たり判定などに使用
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public TileType GetTileTipe(Vector2Int pos)
        {
            if (pos.x < 0 || pos.y <  0 || GameDirector.WIDTH < pos.x || GameDirector.HEIGHT < pos.y)
            {
                Debug.LogError("Not Found");
                return TileType.None;
            }
            else
                return mapData[pos.x, pos.y];
        }


        /// <summary>
        /// タイルマップを描画
        /// </summary>
        /// <param name="field"></param>
        public void ShowField(Field field)
        {
            tilemap.ClearAllTiles();

            for (int x = 0; x < field.Grid.Size.x; x++)
            {
                for (int y = 0; y < field.Grid.Size.y; y++)
                {
                    mapData[x, y] = (TileType)field.Grid[x, y];
                    Tile tile = tiles[(int)mapData[x, y]];
                    tilemap.SetTile(new Vector3Int(x, -y, 0), tile);
                }
            }
        }
    }
}
