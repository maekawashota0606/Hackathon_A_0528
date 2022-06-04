using UnityEngine;

//装備いる？
public class EquipmentItem : ItemBase2
{
    //攻撃力
    [SerializeField]
    private int _atkPoint = 0;

    //防御力
    [SerializeField]
    private int _defPoint = 0;

    public enum Type
    {
        //装備種　例
        Weapon,
        Armor
    }

    [SerializeField]
    Type type;

    #if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Effect();
    }
    #endif

    public override void Effect()
    {
        //Playerの数値変えたい
        if(type == Type.Weapon)
        {
            //Player.Status(_atkPoint);
            Debug.Log("攻撃用");
        }

        else if(type == Type.Armor)
        {
            //Player.Status(_defPoint);
            Debug.Log("防御用");
        }
    }
}