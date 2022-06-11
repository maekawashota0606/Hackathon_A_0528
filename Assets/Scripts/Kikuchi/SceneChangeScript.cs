using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;//’Ç‰Á

public class SceneChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ugoiteru");
        SceneController.Instance.sceneChange("TitleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
