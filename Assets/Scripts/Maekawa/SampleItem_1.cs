//using UnityEngine;

///// <summary>
///// プレイヤーのHPを回復するアイテム
///// </summary>
//public class SampleItem_1 : ItemBase
//{
//    [SerializeField]
//    private int _healPoint = 0;


//#if UNITY_EDITOR
//    // 挙動確認用(適当に削除してよい)
//    private void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Z))
//            Effect();
//    }
//#endif

//    public override void Effect()
//    {
//        // Example 1
//        // プレイヤーの回復関数を呼ぶ(回復の必要がなくても使用される)
//        // 架空の回復関数
//        //Player.Heal(_healPoint);
//        Debug.Log("回復アイテムを使用した。");
//        // 使い切りアイテムならその場で破棄(Destroyは使用しない)
//        base.Trash();

//        // Example 2
//        // boolで戻り値を参照すれば効果がなかった時(HPが既に満タンだったなど)に破棄しないこともできる
//        //if (Player.Heal(_healPoint))
//        //{
//        //    Debug.Log("回復アイテムを使用した。");
//        //    // 使用後、破棄
//        //    base.Trash();
//        //}
//    }
//}
