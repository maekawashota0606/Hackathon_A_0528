using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
#region BGM
    public enum BgmName    //BGMの種類
    {
        //必要に応じて追加して
        test1 = 0,
        test2,
        Silent = 999,
    }

    private AudioSource BgmSource;
    public List<BgmStatus> BgmClips;
    private int[] _bgmNumber;   //BgmNameの項目数の取得

    [System.Serializable]
    public struct BgmStatus  //リスト情報
    {
        [Header("名前")]
        public BgmName Name;
        [Header("音量"), Range(0, 1)]
        public float Volume;
        [Header("BGMデータ")]
        public AudioClip BgmData; //BGM一覧
    }

    private int _currentBgmIndex = 999;  //現在選ばれているBGM番号

    /// <summary>
    /// 再生関数
    /// </summary>
    /// <param name="bgmName">選択したBGM</param>
    public void PlayBGM(BgmName bgmName, bool loopFlg = true)
    {
        int index = (int)bgmName;    //選択されたBGM番号を格納
        _currentBgmIndex = index;    //選択されたBGM番号を再生する為の変数に格納
        if (index == 999) //無音にするときのやつ
        {
            Debug.LogWarning("無音になったよ");
            StopBGM();  //他のBGMをすべてストップさせるよ
            return;
        }
        #region エラー回避用
        if (index < 0 || _bgmNumber.Length <= index)  //選択されたBGM番号があるか確認：数字でPlayBGMを呼び出された際のエラー回避
        {
            Debug.LogWarning("検索できなかったよ");
            return;
        }
        else if (BgmSource.clip != null && BgmSource.clip == BgmClips[index].BgmData) // 同じBGMの場合は何もしない
        {

            Debug.LogWarning("BGMが同じだったよ");
            return;
        }
        #endregion
        else if (!BgmSource.isPlaying)  //再生されていなかったら
        {
            BgmSource.clip = BgmClips[index].BgmData;    //再生するBGMを選択
            BgmSource.volume = BgmClips[index].Volume;  //音量を調整するよー
            BgmSource.Play();    //再生するよー
            return;
        }
    }

    /// <summary>
    /// BGM停止関数
    /// </summary>
    public void StopBGM()
    {
        BgmSource.Stop();    //すべてのBGMを停止
        return;
    }

    /// <summary>
    /// BGM一時停止
    /// </summary>
    public void MuteBGM()
    {
        BgmSource.Stop(); //BGMを一時停止～
    }

    /// <summary>
    /// 止めたBGMを再開する関数
    /// </summary>
    public void ResumeBGM()
    {
        BgmSource.Play(); //止めたBGMを再生～
    }

#endregion

#region  SE

    public enum SeName 
    {
        //必要に応じて追加して
        test = 0,
        test2
    }

    private AudioSource SeSource;
    public List<SeStatus> SeClips;
    private int[] _seNumber;   //SeNameの項目数の取得
    [System.Serializable]
    public struct SeStatus  //リスト情報
    {
        [Header("名前")]
        public SeName Name;
        [Header("音量"), Range(0, 1)]
        public float Volume;
        [Header("SEデータ")]
        public AudioClip SeData; //BGM一覧
    }
    /// <summary>
    /// 再生関数
    /// </summary>
    /// <param name="seName">選択したSE</param>
    public void PlaySE(SeName seName)
    {
        int index = (int)seName;    //選択されたSE番号を格納
        if (index < 0 || _seNumber.Length <= index)  //選択されたSE番号があるか確認：数字でPlaySEを呼び出された際のエラー回避
        {
            Debug.LogWarning("検索できなかったよ");
            return;
        }
        SeSource.clip = SeClips[index].SeData;    //再生するSEを選択
        SeSource.volume = SeClips[index].Volume;  //音量を調整するよー
        SeSource.Play();
        return;
    }

    /// <summary>
    /// SE停止関数
    /// </summary>
    public void StopSE()
    {

        SeSource.Stop();    //すべてのSEを停止

        return;
    }

#endregion
   
    private void Awake()
    {
        BgmSource = gameObject.AddComponent<AudioSource>();
        SeSource = gameObject.AddComponent<AudioSource>();
    }
    private void Start()
    {
        string[] BGM = System.Enum.GetNames(typeof(BgmName));    //string[]→int[]に変換
        _bgmNumber = new int[BGM.Length];    //intに変換

        string[] SE = System.Enum.GetNames(typeof(SeName));    //string[]→int[]に変換
        _seNumber = new int [SE.Length];    //intに変換

    }
}
