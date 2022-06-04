using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    protected string _itemName = string.Empty;

    public string GetItemName()
    {
        return _itemName;
    }

    /// <summary>
    /// プレイヤーなどがアイテムを使用したときに呼ばれる、アイテムの効果が適用される
    /// </summary>
    public abstract void Effect();

    protected virtual void Trash()
    {
        transform.position = new Vector3(9999, 9999);
        Debug.Log(_itemName + "はなくなった。");
    }
}
