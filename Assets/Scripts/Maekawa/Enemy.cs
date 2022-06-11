using UnityEngine;

public class Enemy : Actor
{
    [SerializeField]
    private int _exp = 35;
    private Vector2Int _position = new Vector2Int(0, 0);

    public void SetPosition(Vector2Int pos)
    {
        _position = pos;
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public Vector2Int GetPosition()
    {
        return _position;
    }

    public void Init()
    {
        _HP = _maxHP;
    }

    private void Move()
    {
        Vector2Int playerPos = GameDirector.Instance.GetPlayer().GetPlayerPos();
        Vector2Int prePos = _position;
        Vector2Int[] deltaPos = new Vector2Int[(int)IActor.Dir.Size];
        int value = 99999999;


        for (int i = 0; i < (int)IActor.Dir.Size; i++)
        {
            deltaPos[i] = prePos + GetMoveDirection(i);
            if (GameDirector.Instance.IshitWall(deltaPos[i]) || GameDirector.Instance.IsHitEnemies(deltaPos[i]) || GameDirector.Instance.IsHItPlayer(deltaPos[i]))
                continue;

            int v = MyMath.CalDistance(deltaPos[i], playerPos);
            if (v < value)
            {
                value = v;
                SetPosition(deltaPos[i]);
                //Debug.Log("Move");
            }
        }
    }

    private bool Attack()
    {
        for(int i = 0; i < (int)IActor.Dir.Size; i++)
        {
            Vector2Int checkPos = _position;
            for(int j = 0; j < _attackRange; j++)
            {
                checkPos += GetMoveDirection(i);
                //Debug.Log(checkPos);
                if (GameDirector.Instance.IsHItPlayer(checkPos))
                {
                    GameDirector.Instance.GetPlayer().AddDamage(_power);
                    Debug.Log("EnemyAttacksHit");
                    return true;
                }    
            }
        }

        return false;
    }

    public void AddDamage(int damage)
    {
        _HP -= damage;
        if(_HP < 1)
        {
            GameDirector.Instance.GetPlayer().AddEXP(_exp);
            GameDirector.Instance.DeleteEnemy(this);
        }    
    }

    public override void Action()
    {
        for(int i = 0; i < _speed; i++)
        {
            if (!Attack())
                Move();
        }
    }
}
