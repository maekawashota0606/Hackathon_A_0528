using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerObj;
    [SerializeField]
    private GameObject EnemyObj;

    [SerializeField]
    private int EnemyPositionX;

    [SerializeField]
    private int EnemyPositionY;


    private TestMapManager _testMapManager;

    private TestPlayerController _testPlayerController;

    private Vector2 PlayerPos;

    private Vector2 EnemyPos;

    private bool IsPlayerMove = false;


    void Start()
    {

        _testMapManager = GetComponent<TestMapManager>();
        _testPlayerController = GetComponent<TestPlayerController>();
    }

    void Update()
    {

        PlayerPos = PlayerObj.transform.position;

        EnemyPos.x = EnemyPositionX;
        EnemyPos.y = EnemyPositionY;

        if (Input.GetMouseButtonDown(0))    //‚±‚±‚É IsPlayerMove‚Ì”»’è‚ð“ü‚ê‚éB
        {
            if (PlayerPos.x > EnemyPositionX)
            {
                EnemyPositionX += 1;
            }
            else if(PlayerPos.x < EnemyPositionX)
            {
                EnemyPositionX -= 1;
            }


            if (PlayerPos.y > EnemyPositionY)
            {
                EnemyPositionY += 1;
            }
            else if (PlayerPos.y < EnemyPositionY)
            {
                EnemyPositionY -= 1;
            }
            EnemyPos.x = EnemyPositionX;
            EnemyPos.y = EnemyPositionY;

            IsPlayerMove = false;

        }
    }

}
