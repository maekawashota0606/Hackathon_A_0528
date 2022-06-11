using UnityEngine;

public class MaskController : SingletonMonoBehaviour<MaskController>
{
    [SerializeField]
    private Vector3 _defaultSize = new Vector3(6, 6);
    [SerializeField]
    private SpriteMask _mask = null;

    public void Init()
    {
        _mask.gameObject.transform.localScale = _defaultSize;
    }

    public void ChangeView(int level)
    {
        int additionalSize = 1 * (level - 1);
        _mask.gameObject.transform.localScale = _defaultSize + new Vector3(additionalSize, additionalSize);
    }
}
