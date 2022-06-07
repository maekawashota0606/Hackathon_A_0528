using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        //SceneController.Instance.sceneChange("FirstScene");
        DontDestroyOnLoad(gameObject);
    }
}



