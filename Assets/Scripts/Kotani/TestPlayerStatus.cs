using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerStatus : MonoBehaviour
{
    #region 基礎ステータス
    [Header("基礎ステータス")]
    [SerializeField]
    private int _hp;     //体力
    [SerializeField]
    private int _hunger; //空腹
    [SerializeField]
    private int _atk;    //攻撃力
    private int _maxHp;     //最大体力
    private int _maxHunger; //最大空腹
    
    public int GetHp(){return _hp;}
    public int GetHunger(){return _hunger;}
    public int GetAtk(){return _atk;}
    public int GetMaxHp(){return _maxHp;}
    public int GetMaxHunger(){return _maxHunger;}
    public void SetHp(int Value){_hp = Value;}
    public void SetHunger(int Value){_hunger = Value;}
    public void SetMaxHp(int Value){_maxHp = Value;}
    public void SetMaxHunger(int Value){_maxHunger = Value;}
    #endregion

    #region 五感に関するステータス
    [Header("五感に関するステータス")]
    [SerializeField,Range(1, 5)]
    private int _vision = 1;     //視覚
    [SerializeField,Range(1, 5)]
    private int _hearing = 1;    //聴覚
    [SerializeField,Range(1, 5)]
    private int _feeler = 1;     //触角
    [SerializeField,Range(1, 5)]
    private int _taste = 1;      //味覚
    [SerializeField,Range(1, 5)]
    private int _olfaction = 1;  //嗅覚
    #region Get
    public int GetVision(){return _vision;}
    public int GetHearing(){return _hearing;}
    public int GetFeeler(){return _feeler;}
    public int GetTaste(){return _taste;}
    public int GetOlfaction(){return _olfaction;}
    #endregion
    #region Set
    public void SetOlfaction(int Value){_vision = _olfaction;}
    public void SetTaste(int Value){_vision = _taste;}
    public void SetFeeler(int Value){_vision = _feeler;}
    public void SetHearing(int Value){_vision = _hearing;}
    public void SetVision(int Value){_vision = Value;}
    #endregion
    #endregion
    void Start()
    {
        _maxHp = _hp;
        _maxHunger = _hunger;
    }

}
