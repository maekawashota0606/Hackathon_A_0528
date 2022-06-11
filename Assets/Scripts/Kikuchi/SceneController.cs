using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;//追加
using UnityEngine.SceneManagement;//追加

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    private string currentScene = "TitleScene";
    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public FadeManager fadeCanvas;//操作するCanvas、タグで探す
    public bool isChanging = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void Init()
    {
        //Debug.Log("できたよ");
        SceneManager.LoadScene("FirstScene",LoadSceneMode.Additive);
    }
    void Start()
    {
        //Debug.Log("start");
        fadeCanvas.fadeIn();
        //if (!FadeManager.isFadeInstance)//isFadeInstanceは後で用意する
        //{
            //Instantiate(fade);
        //}
        //Invoke("findFadeObject", 0.02f);//起動時用にCanvasの召喚をちょっと待つ
    }
    void findFadeObject()
    {
        //fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvasをみつける
        //fadeCanvas.fadeIn();//フェードインフラグを立てる
    }

    public async void sceneChange(string PreviewScene)//ボタン操作などで呼び出す
    {
        //Debug.Log("change");
        if(isChanging)
        {
            return;
        }
        else
        {
            isChanging = true;
        }
        SceneManager.sceneLoaded += SceneLoaded; // イベントにイベントハンドラーを追加
        fadeCanvas.fadeOut();//フェードアウトフラグを立てる
        await Task.Delay(1000);//暗転するまで待つ
        //Debug.Log(PreviewScene+"PreviewScene");
        SceneManager.LoadScene(PreviewScene, LoadSceneMode.Additive);//シーンチェンジ
    }
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        //Debug.Log(nextScene.name);
        //Debug.Log(mode);
        fadeCanvas.fadeIn();
        //Debug.Log(currentScene+"DestroyScene");
        SceneManager.UnloadScene(currentScene);
        //for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        currentScene = SceneManager.GetSceneAt(1).name;//読み込まれているシーンを取得し、その名前をログに表示
        //Debug.Log(currentScene+ "currentScene");
        SceneManager.sceneLoaded -= SceneLoaded;
        isChanging = false;
    }
}