using UnityEngine;
using UnityEngine.Tilemaps;

namespace RandomDungeonWithBluePrint
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap = default;
        [SerializeField] private Tile floorTile = default;
        [SerializeField] private Tile wallTile = default;

        private const int MAX_WIDTH = 99;
        private const int MAX_HEIGHT = 99;
        private int[,] map = new int[MAX_WIDTH, MAX_HEIGHT];

        public void ShowField(Field field)
        {
            tilemap.ClearAllTiles();

            for (int i = 0; i < MAX_WIDTH; i++)
                for (int j = 0; j < MAX_HEIGHT; j++)
                    map[i, j] = -1;

            string s = string.Empty;

            for (var x = 0; x < field.Grid.Size.x; x++)
            {
                for (var y = 0; y < field.Grid.Size.y; y++)
                {
                    s += field.Grid[x, y].ToString();
                    map[x, y] = field.Grid[x, y];
                    //
                    var tile = field.Grid[x, y] == (int) Constants.MapChipType.Wall ? wallTile : floorTile;
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }

            for (int i = 0; i < MAX_WIDTH; i++)
            {
                for (int j = 0; j < MAX_HEIGHT; j++)
                {
                    s += map[i, j];
                }
                s += "\n";
            }
            Debug.Log(s);
        }
    }
}
