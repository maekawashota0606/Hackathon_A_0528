using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiDisplayController : MonoBehaviour
{
    [SerializeField]
    private TestPlayerStatus _testPlayerStatus;
    [SerializeField]
    private TextMeshProUGUI _hpValueText;
    [SerializeField]
    private TextMeshProUGUI _hungryValueText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UiDisp();
    }
    public void UiDisp()
    {
        _hpValueText.text = _testPlayerStatus.GetMaxHp()+"/"+_testPlayerStatus.GetHp();
        _hungryValueText.text = _testPlayerStatus.GetMaxHunger()+"/"+_testPlayerStatus.GetHunger();
    }
}
