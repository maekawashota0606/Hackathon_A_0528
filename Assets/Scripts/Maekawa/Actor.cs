using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IActor
{
    public void Action()
    {
        
    }

    public Vector2Int MoveDown()
    {
        return new Vector2Int(0, 1);
    }

    public Vector2Int MoveLeft()
    {
        return new Vector2Int(-1, 0);
    }

    public Vector2Int MoveRight()
    {
        return new Vector2Int(1, 0);
    }

    public Vector2Int MoveUp()
    {
        return new Vector2Int(0, -1);
    }
}
