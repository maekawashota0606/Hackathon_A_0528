using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneralManager.Instance.SoundM.PlaySE(SoundManager.SeName.test);
            Debug.Log("���e�X�g");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GeneralManager.Instance.SoundM.PlayBGM(SoundManager.BgmName.test1);
            Debug.Log("���e�X�g");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            GeneralManager.Instance.SoundM.ResumeBGM();
            Debug.Log("���e�X�g");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GeneralManager.Instance.SoundM.PlayBGM(SoundManager.BgmName.test2);
            Debug.Log("���e�X�g");
        }
    }
}
