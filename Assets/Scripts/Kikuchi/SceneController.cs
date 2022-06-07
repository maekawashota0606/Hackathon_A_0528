using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;//�ǉ�
using UnityEngine.SceneManagement;//�ǉ�

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    private string currentScene = "TitleScene";
    public GameObject fade;//�C���X�y�N�^����Prefab������Canvas������
    public FadeManager fadeCanvas;//���삷��Canvas�A�^�O�ŒT��
    public bool isChanging = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void Init()
    {
        //Debug.Log("�ł�����");
        SceneManager.LoadScene("FirstScene",LoadSceneMode.Additive);
    }
    void Start()
    {
        //Debug.Log("start");
        fadeCanvas.fadeIn();
        //if (!FadeManager.isFadeInstance)//isFadeInstance�͌�ŗp�ӂ���
        //{
            //Instantiate(fade);
        //}
        //Invoke("findFadeObject", 0.02f);//�N�����p��Canvas�̏�����������Ƒ҂�
    }
    void findFadeObject()
    {
        //fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvas���݂���
        //fadeCanvas.fadeIn();//�t�F�[�h�C���t���O�𗧂Ă�
    }

    public async void sceneChange(string PreviewScene)//�{�^������ȂǂŌĂяo��
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
        SceneManager.sceneLoaded += SceneLoaded; // �C�x���g�ɃC�x���g�n���h���[��ǉ�
        fadeCanvas.fadeOut();//�t�F�[�h�A�E�g�t���O�𗧂Ă�
        await Task.Delay(1000);//�Ó]����܂ő҂�
        //Debug.Log(PreviewScene+"PreviewScene");
        SceneManager.LoadScene(PreviewScene, LoadSceneMode.Additive);//�V�[���`�F���W
    }
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        //Debug.Log(nextScene.name);
        //Debug.Log(mode);
        fadeCanvas.fadeIn();
        //Debug.Log(currentScene+"DestroyScene");
        SceneManager.UnloadScene(currentScene);
        //for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        currentScene = SceneManager.GetSceneAt(1).name;//�ǂݍ��܂�Ă���V�[�����擾���A���̖��O�����O�ɕ\��
        //Debug.Log(currentScene+ "currentScene");
        SceneManager.sceneLoaded -= SceneLoaded;
        isChanging = false;
    }
}