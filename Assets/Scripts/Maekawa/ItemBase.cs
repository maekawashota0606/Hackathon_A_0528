using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    protected string _itemName = string.Empty;
    protected Vector2Int _position = new Vector2Int(0, 0);

    public string GetItemName()
    {
        return _itemName;
    }

    public void SetPosition(Vector2Int pos)
    {
        _position = pos;
        transform.position = new Vector3(_position.x, _position.y, 0);
    }

    public Vector2Int GetPosition()
    {
        return _position;
    }

    /// <summary>
    /// プレイヤーなどがアイテムを使用したときに呼ばれる、アイテムの効果が適用される
    /// </summary>
    public abstract bool Effect();

    protected virtual void Trash()
    {
        transform.position = new Vector3(9999, 9999);
        Debug.Log(_itemName + "はなくなった。");
    }
}
