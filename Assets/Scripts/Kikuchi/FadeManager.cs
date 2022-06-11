using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//追加

public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
    //public static bool isFadeInstance = false;//Canvas召喚フラグ

    public bool isFadeIn = false;//フェードインするフラグ
    public bool isFadeOut = false;//フェードアウトするフラグ

    public float alpha = 0.0f;//透過率、これを変化させる
    public float fadeSpeed = 0.2f;//フェードに掛かる時間

    void Start()
    {
        //if (!isFadeInstance)//起動時
        //{
            //DontDestroyOnLoad(this);
            //isFadeInstance = true;
        //}
        //else//起動時以外は重複しないようにする
        //{
           // Destroy(this);
        //}
    }
    void Update()
    {
        if (isFadeIn)
        {
            //Debug.Log("Fadein");
            alpha -= Time.deltaTime / fadeSpeed;
            if (alpha <= 0.0f)//透明になったら、フェードインを終了
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (isFadeOut)
        {
            //Debug.Log("Fadeout");
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 1.0f)//真っ黒になったら、フェードアウトを終了
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    //ここの下を呼べばフェードイン、アウトの実装可能
    public void fadeIn() // 画面を明るくする
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    public void fadeOut() // 画面を暗くする
    {
        isFadeOut = true;
        isFadeIn = false;
    }
}

