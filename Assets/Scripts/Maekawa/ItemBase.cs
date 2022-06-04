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
    /// �v���C���[�Ȃǂ��A�C�e�����g�p�����Ƃ��ɌĂ΂��A�A�C�e���̌��ʂ��K�p�����
    /// </summary>
    public abstract void Effect();

    protected virtual void Trash()
    {
        transform.position = new Vector3(9999, 9999);
        Debug.Log(_itemName + "�͂Ȃ��Ȃ����B");
    }
}
