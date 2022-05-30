using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestMapManager : MonoBehaviour
{
    ///////////////////////////////////
    ///配列でmapを管理するためのもの
    ///0がマス無し,1が通常のマス,2で壁で,3で階段マップの生成
    ///////////////////////////////////

    #region  SerializeField宣言
    [SerializeField]
    private GameObject MapObject;
    [SerializeField]
    private List<Sprite> MapSpriteList = new List<Sprite>();
    [SerializeField]
    private TestPlayerController _testPlayerController;
    #endregion
    #region 内部処理でしか使わない宣言
    //ゲームオブジェクトをいれるやつ
    private List<GameObject> MapImageList = new List<GameObject>();
    private int[] TestMapArray =new int[0];
    public int[] GetTestMapArray()
    {
        return TestMapArray;
    }
    //とりあえず10×10での作成(将来的にはcsv読み込みで使う)
    private int[] CreateMapArray = {2,2,2,2,2,2,2,2,2,2,
                                    2,3,1,1,1,1,1,1,1,2,
                                    2,1,1,1,1,1,1,1,1,2,
                                    2,1,1,1,1,1,1,1,1,2,
                                    2,1,1,1,1,1,1,0,0,2,
                                    2,1,1,1,1,1,1,1,1,2,
                                    2,1,1,1,1,1,1,1,1,2,
                                    2,1,1,1,1,1,1,1,1,2,
                                    2,1,1,1,1,1,1,1,1,2,
                                    2,2,2,2,2,2,2,2,2,2};
    #endregion

    void Awake()
    {
        SetMapObject();
        CreateMap(CreateMapArray);
        _testPlayerController.SetMapSize(TestMapArray);
    }

    #region マップの中身を全て0にする処理
    private void ReSet()
    {
        for (int i = 0; i < TestMapArray.Length; i++)
        {
        TestMapArray[i] = 0;
        }
    }
    #endregion

    #region Mapの画像を設定する処理
    private void CreateMap(int[] Value)
    {
        for (int i = 0; i <= Value.Length-1; i++)
        {
        Array.Resize(ref TestMapArray, TestMapArray.Length + 1);
        TestMapArray[i] = Value[i];
        SetMapImage(i,TestMapArray[i]);
        }
    }
    //0がマス無し,1が通常のマス,2で壁で,3で階段マップの生成
    private void SetMapImage(int i,int Value)//（配列の何番目）
    {
        MapImageList[i].GetComponent<SpriteRenderer>().sprite = MapSpriteList[Value];
    }
    #endregion

    #region GameObjectを格納する処理
    private void SetMapObject()
    {
        for(int a = 0; a <= 9; a++)
        {
            for (int i = 1; i < 11; i++)
            {
                if(a == 0)
                {
                MapImageList.Add(MapObject.transform.Find("Horizon").transform.Find(i.ToString()).gameObject);
                }
                else
                {
                MapImageList.Add(MapObject.transform.Find("Horizon("+a+")").transform.Find(i.ToString()).gameObject);
                }
            }
        }
    }
    #endregion
}
