using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField]
    private TestPlayerController _testPlayerController;
    [SerializeField]
    private TestPlayerStatus _testPlayerStatus;

    void Update()
    {
        if(_testPlayerController.PlayerMoveFlag == false)
        {
            _testPlayerController.PlayerWalk();
        }
        else
        {
            _testPlayerStatus.SetHunger(_testPlayerStatus.GetHunger()-1);
            _testPlayerController.PlayerMoveFlag=false;
        }

        //Playerが行動したら１減らす
    }
}
