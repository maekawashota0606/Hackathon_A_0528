using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    [SerializeField]
    private Vector2 _mapNum;
    [HideInInspector]
    public int[,] MapArray;

    private void Awake()
    {
        MapArray = new int[(int)_mapNum.x, (int)_mapNum.y];
    }
    private void Start()
    {
        CreateMap();
    }
    /// <summary>
    /// ƒ}ƒbƒv‚Ìî•ñ‚ğŠi”[
    /// </summary>
    private void CreateMap()
    {
        for (int x = 0; x < _mapNum.x; x++)
        {
            for (int y = 0; y < _mapNum.y; y++)
            {
                if (x == 0 || y == 0 || x == _mapNum.x - 1 || y == _mapNum.y - 1)
                    MapArray[x, y] = 2;
                else
                    MapArray[x, y] = 1;
            }
        }
    }
}
