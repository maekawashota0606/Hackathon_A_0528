using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OldEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerPrefab;

    private Vector2 PlayerPos;

    private Vector2 EnemyPos;

    private bool IsPlayerMove = false;
    void Start()
    {
        PlayerPrefab = GameObject.FindWithTag("Player");
        PlayerPos=PlayerPrefab.transform.position;
        EnemyPos =this.transform.position;

        //�}�l�[�W���[����v���C���[�����������̔��������Ă���B

    }

    void Update()
    {

        PlayerPos = PlayerPrefab.transform.position;
        EnemyPos = this.transform.position;

        if (Input.GetMouseButtonDown(0))    //������ IsPlayerMove�̔��������B
        {
            if (PlayerPos.x > EnemyPos.x)
            {
                EnemyPos.x += 1;
            }
            else if (PlayerPos.x < EnemyPos.x)
            {
                EnemyPos.x -= 1;
            }

            if (PlayerPos.y > EnemyPos.y)
            {
                EnemyPos.y += 1;
            }
            else if (PlayerPos.y < EnemyPos.y)
            {
                EnemyPos.y -= 1;
            }

            EnemyPos = transform.position;

            IsPlayerMove = false;

        }
    }

}
