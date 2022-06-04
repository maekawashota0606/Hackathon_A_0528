using UnityEngine;

//ダメージとまとめていいレベル

/// <summary>
/// 回復用
/// </summary>
public class HealItem : ItemBase2
{
    //回復量
    [SerializeField]
    private int _healPoint;

    //使用回数
    [SerializeField]
    private int _count = 0;

    #if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
            Effect();
    }
    #endif

    public override void Effect()
    {
        Debug.Log(_healPoint + "回復した");
        
        if(_count != 1)
        {
             _count--;
            Debug.Log(_count);
        }

        else if(_count == 1)
        {
            base.Trash();
        }
    }
}