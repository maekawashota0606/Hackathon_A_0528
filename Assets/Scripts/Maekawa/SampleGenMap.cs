using UnityEngine;

public class SampleGenMap : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //雑にシード値を与える
            RandomDungeonWithBluePrint.MapGenerator.Instance.GenerateMap(Time.frameCount);
        }
    }
}
