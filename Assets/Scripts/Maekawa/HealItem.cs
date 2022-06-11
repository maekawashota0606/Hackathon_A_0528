using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : ItemBase
{
    [SerializeField]
    private int _healPoint = 20;

    public override bool Effect()
    {
        if (GameDirector.Instance.GetPlayer().Heal(_healPoint))
        {
            Debug.Log("Heal");
            base.Trash();
            return true;
        }
        else
            return false;
    }
}
