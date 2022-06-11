using UnityEngine;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI _floorText = null;
    [SerializeField]
    private TextMeshProUGUI _levelText = null;
    [SerializeField]
    private TextMeshProUGUI _HPText = null;

    public void SetFloorText(int floor)
    {
        _floorText.text = floor.ToString() + "F";
    }

    public void SetLevelText(int level)
    {
        _levelText.text = "Lv." + level.ToString();
    }

    public void SetHPText(int hp, int maxHp)
    {
        _HPText.text = hp.ToString() + "/" + maxHp.ToString();
    }
}
