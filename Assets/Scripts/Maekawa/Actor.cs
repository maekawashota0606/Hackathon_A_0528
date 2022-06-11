using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IActor
{
    [SerializeField]
    protected int _maxHP = 60;
    [SerializeField]
    protected int _attackRange = 1;
    [SerializeField]
    protected int _power = 20;
    [SerializeField]
    protected int _speed = 1;
    protected int _HP = 0;

    public virtual void Action()
    {
        
    }

    public Vector2Int GetMoveDirection(int dir)
    {
        Vector2Int movePos = new Vector2Int(0, 0);
        switch ((IActor.Dir)dir)
        {
            case IActor.Dir.Up:
                movePos = MoveUp();
                break;
            case IActor.Dir.Left:
                movePos = MoveLeft();
                break;
            case IActor.Dir.Right:
                movePos = MoveRight();
                break;
            case IActor.Dir.Down:
                movePos = MoveDown();
                break;
            default:
                break;
        }

        return movePos;
    }

    public Vector2Int MoveDown()
    {
        return new Vector2Int(0, -1);
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
        return new Vector2Int(0, 1);
    }
}
