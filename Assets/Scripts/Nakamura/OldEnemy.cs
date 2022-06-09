using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OldEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerPrefab;

    private Vector2Int PlayerPos;

    private Vector2Int EnemyPos;

    private bool IsPlayerMove = false;

    private int AttackRange = 1;

    private int HP = 5;

    private int Damage = 1;



    void Start()
    {
        PlayerPrefab = GameObject.FindWithTag("Player");

        PlayerPos = new Vector2Int(1, 0);//仮でプレイヤーの位置を決定
        
        EnemyPos = new Vector2Int(0, 0);


    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ActionEnemy();

        }


        #region　使わないコード（消していいかも）
        //PlayerPos = PlayerPrefab.transform.position;
        //EnemyPos = this.transform.position;

        //if (Input.GetMouseButtonDown(0))    //ここに IsPlayerMoveの判定を入れる。
        //{
        //    if (PlayerPos.x > EnemyPos.x)
        //    {
        //        EnemyPos.x += 1;
        //    }
        //    else if (PlayerPos.x < EnemyPos.x)
        //    {
        //        EnemyPos.x -= 1;
        //    }

        //    if (PlayerPos.y > EnemyPos.y)
        //    {
        //        EnemyPos.y += 1;
        //    }
        //    else if (PlayerPos.y < EnemyPos.y)
        //    {
        //        EnemyPos.y -= 1;
        //    }

        //    transform.position= EnemyPos ;

        //    IsPlayerMove = false;

        //}
        #endregion
    }

    private void MoveEnemy()
    {

        if(RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(EnemyPos)==RandomDungeonWithBluePrint.Map.TileType.Floor)
        {
            if (PlayerPos.x > EnemyPos.x)
            {
                EnemyPos.x += 1;
                
            }
            else if (PlayerPos.x < EnemyPos.x)
            {
                EnemyPos.x -= 1;
            }
            else if (PlayerPos.y > EnemyPos.y)
            {
                EnemyPos.y += 1;
            }
            else if (PlayerPos.y < EnemyPos.y)
            {
                EnemyPos.y -= 1;
            }

            Vector2 position = EnemyPos;

            transform.position = position;

        }

        //プレイヤーの座標を取得（後で追加）
        //移動する前に、移動後のマスに移動できるか（前後左右に壁があるなどを調べる）
        //　>いけない方向があった場合その選択を除外する。
        //　>どこにも移動できない場合は移動をやめる。
        //移動する方向（一ターンでの方向）
        //移動が成功したら、移動後の座標をEnemyposの変数にセット
        //gameobjrctの座標をEnemyposの変数にセット

    }

    private bool AttackEnemy()
    {
        //右方向
        for(int i = 1; i < AttackRange+1; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(i, 0);
            if(PlayerPos==serchpos)
            {
                //攻撃処理

                Debug.Log("右");

                return true;
            }
        }
        //左方向
        for (int i = 1; i < AttackRange; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(-i, 0);
            if (PlayerPos == serchpos)
            {
                //攻撃処理
                Debug.Log("左");

                return true;
            }
        }
        //上方向
        for (int i = 1; i < AttackRange; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(0, i);
            if (PlayerPos == serchpos)
            {
                //攻撃処理
                Debug.Log("上");

                return true;
            }
        }
        //下方向
        for (int i = 1; i < AttackRange; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(0, -i);
            if (PlayerPos == serchpos)
            {
                //攻撃処理
                Debug.Log("下");

                return true;
            }
        }

        return false;

    }

    public void ActionEnemy()
    {
        if(!AttackEnemy())
        {
            MoveEnemy();
        }

    }

    public void AddDamage(int damage)
    {
        HP = -damage;

        if(HP <= 0)
        {
            //死亡時の処理
        }

    }

}
