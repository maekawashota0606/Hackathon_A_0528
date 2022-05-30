using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField]
    private TestMapManager _testMapManager;
    [SerializeField]
    private int PlayerPositionX;
    [SerializeField]
    private int PlayerPositionY;

    private bool DontWalkFlag = false;

    //プレイヤーの位置を把握するために必要なもの
    [SerializeField]
    private int[] _playerMapPosition =new int[0];
    #region _playerMapPositionのgetset
    public int[] GetPlayerMapPosition()
    {
        return _playerMapPosition;
    }
    public void SetPlayerMapPosition(int[] Value)
    {
        _playerMapPosition = Value;
    }
    #endregion

    void Start()
    {
        SetPlayerPosition(PlayerPositionX,PlayerPositionY);
        PlayerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
    }

    #region 移動処置
    public void PlayerWalk()
    {
    Vector2 _pos = _playerObject.transform.position;
    
    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
    {
        SetPlayerPosition(PlayerPositionX+1,PlayerPositionY);
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
    {
        SetPlayerPosition(PlayerPositionX-1,PlayerPositionY);
    }
    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    {
        SetPlayerPosition(PlayerPositionX,PlayerPositionY-1);
    }
    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
    {
        SetPlayerPosition(PlayerPositionX,PlayerPositionY+1);
    }
    }
    #endregion

    #region 移動の禁則処理
    private void PlayerDontWalkRule(int x,int y)
    {
        y *= 10;
        x= x+y;
        switch(_testMapManager.GetTestMapArray()[x])
        {
            case 0:
            Debug.Log("先は暗闇だよ");
            DontWalkFlag=true;
            break;
            case 1:
            DontWalkFlag=false;
            break;
            case 2:
            Debug.Log("先は壁だよ");
            DontWalkFlag=true;
            break;
            case 3:
            Debug.Log("先は階段だよ");
            break;
        }
    }
    #endregion

    #region Playerの初期位置を表示する処理
    private void PlayerDisplay()
    {
        Vector2 _pos = _playerObject.transform.position;

        _pos.y -= PlayerPositionY;
        _pos.x += PlayerPositionX;
        _playerObject.transform.position = _pos;
    }
    #endregion

     #region プレイヤーの位置をマップと同期させるための処理
    public void SetMapSize(int[] Value)
    {
        Array.Resize(ref _playerMapPosition,Value.Length );
    }
    public void SetPlayerPosition(int x,int y)
    {
        Vector2 _pos = _playerObject.transform.position;
        //今は10×10の想定
        //左右は+-1
        //上下は+-10
        PlayerDontWalkRule(x,y);
        if(DontWalkFlag == false)
        {
            _pos.x -= PlayerPositionX - x;
            _pos.y += PlayerPositionY - y;
            _playerObject.transform.position = _pos;

            int reset = 0;
            reset = (PlayerPositionY*10)+PlayerPositionX;
            _playerMapPosition[reset]=0;

            PlayerPositionX=x;
            PlayerPositionY=y;
            y *= 10;
            x= x+y;
            _playerMapPosition[x]=1;
        }
    }
    #endregion

}
