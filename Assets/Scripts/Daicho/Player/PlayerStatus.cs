using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public Vector2 PlayerPos = Vector2.zero; //現在のプレイヤー座標
    [Header("プレイヤーの体力")]
    public int Hp;
    [Header("プレイヤーの移動速度")]
    public int MoveSpeed;
    /// <summary>
    /// 回復する関数
    /// </summary>
    public void Heal()
    {
        var healNum = 0;    //回復量は調整すべし 回復量を引数に与えてもよし

        Hp += healNum;
    }
}
