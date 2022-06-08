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

        PlayerPos = new Vector2Int(1, 0);//���Ńv���C���[�̈ʒu������
        
        EnemyPos = new Vector2Int(0, 0);


    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ActionEnemy();

        }


        #region�@�g��Ȃ��R�[�h�i�����Ă��������j
        //PlayerPos = PlayerPrefab.transform.position;
        //EnemyPos = this.transform.position;

        //if (Input.GetMouseButtonDown(0))    //������ IsPlayerMove�̔��������B
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

        //�v���C���[�̍��W���擾�i��Œǉ��j
        //�ړ�����O�ɁA�ړ���̃}�X�Ɉړ��ł��邩�i�O�㍶�E�ɕǂ�����Ȃǂ𒲂ׂ�j
        //�@>�����Ȃ��������������ꍇ���̑I�������O����B
        //�@>�ǂ��ɂ��ړ��ł��Ȃ��ꍇ�͈ړ�����߂�B
        //�ړ���������i��^�[���ł̕����j
        //�ړ�������������A�ړ���̍��W��Enemypos�̕ϐ��ɃZ�b�g
        //gameobjrct�̍��W��Enemypos�̕ϐ��ɃZ�b�g

    }

    private bool AttackEnemy()
    {
        //�E����
        for(int i = 1; i < AttackRange+1; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(i, 0);
            if(PlayerPos==serchpos)
            {
                //�U������

                Debug.Log("�E");

                return true;
            }
        }
        //������
        for (int i = 1; i < AttackRange; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(-i, 0);
            if (PlayerPos == serchpos)
            {
                //�U������
                Debug.Log("��");

                return true;
            }
        }
        //�����
        for (int i = 1; i < AttackRange; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(0, i);
            if (PlayerPos == serchpos)
            {
                //�U������
                Debug.Log("��");

                return true;
            }
        }
        //������
        for (int i = 1; i < AttackRange; i++)
        {
            Vector2Int serchpos = EnemyPos + new Vector2Int(0, -i);
            if (PlayerPos == serchpos)
            {
                //�U������
                Debug.Log("��");

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
            //���S���̏���
        }

    }

}
