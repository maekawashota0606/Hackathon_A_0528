using UnityEngine;

//自分に
//継続 or 一発　ダメージ
public class DamageItem : ItemBase2
{
    //ダメージ量
    [SerializeField]
    private int _damagePoint = 0;

    //使用回数
    [SerializeField]
    private int _count = 0;

    public enum CharacterType
    {
        //対象が自分か敵か
        Player,

        Enemy,
    }

    [SerializeField]
    CharacterType charaType;

    #if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            Effect();
    }
    #endif

    public override void Effect()
    {
        //使用じゃなくて通っただけでここに来てほしさある
        if(charaType == CharacterType.Player)
        {
            //Player.Damage(_damagePoint);
            Debug.Log("自分だよ");
        }

        else if(charaType == CharacterType.Enemy)
        {
            //Enemy.Damage(_damagePoint);
            //近くに対象がいるかどうかみたいなやつはEnemy側に任せたさある
            Debug.Log(_damagePoint + "ダメージを与えた");
            
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
}