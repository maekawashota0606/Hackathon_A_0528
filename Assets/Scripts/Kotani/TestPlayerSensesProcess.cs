using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerSensesProcess : MonoBehaviour
{
    [SerializeField]
    private TestPlayerStatus _testPlayerStatus;
    [SerializeField]
    private Camera _camera;

    void Start()
    {
        VisionProcess();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _testPlayerStatus.SetVision(_testPlayerStatus.GetVision()+1);
            VisionProcess();
        }
    }
    //五感のレベル情報が流れて来るのでそれに対応した値を渡す
    public void SensesReference(string SenseName)
    {
        switch(SenseName)
        {
            case "vision":
            VisionProcess();
            break;
            case "hearing":
            HearingProcess();
            break;
            case "feeler":
            FeelerProcess();
            break;
            case "taste":
            TasteProcess();
            break;
            case "olfaction":
            OlfactionProcess();
            break;
            default:
            Debug.Log("NotName"+SenseName);
            break;
        }
    }

    //視覚：画面の見える範囲が変化
    private void VisionProcess()
    {
        //レベルに応じてカメラサイズ変更
        _camera.orthographicSize = _testPlayerStatus.GetVision();
    }
    //聴覚：相手の場所がおおよそわかる
    private void HearingProcess()
    {
        //Hearingの値を確認
        //レベルに応じてマップに見える敵が増える
        
    }
    //触角：ダメージが少なくなる
    private void FeelerProcess()
    {
        //Feelerの値を確認
        //ダメージが軽くなる
    }
    //味覚：HP回復量が上がる
    private void TasteProcess()
    {
        //Tasteの値を確認
        //Hpの回復量が上がる
    }
    //嗅覚：
    private void OlfactionProcess()
    {
        //olfactionの値を確認する
        //Hungerの回復量が上がる
    }

    
}
