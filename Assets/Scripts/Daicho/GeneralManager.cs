using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundManager))]

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager Instance = null;  //ゲームマネージャは一つしかないよっていうやつ

    [HideInInspector]
    public SoundManager SoundM;  //SoundManagerを格納するやつだ！！
    private void Awake()    //スタートの前に呼び出すよ
    {
        if(Instance == null)    //もしゲームマネージャーがなかった場合に呼ぶよ
        {
            Instance = this;    //こいつが世界に一つのマネージャーになるよ
            DontDestroyOnLoad(this.gameObject); //このオブジェクトは消せねえ！ってするやつ
        }
        SoundM = GetComponent<SoundManager>(); //SoundManagerを管理するぜ！！
    }
}
