using UnityEngine;

public class SampleGenMap : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //�G�ɃV�[�h�l��^����
            RandomDungeonWithBluePrint.MapGenerator.Instance.GenerateMap(Time.frameCount);
        }
    }
}
