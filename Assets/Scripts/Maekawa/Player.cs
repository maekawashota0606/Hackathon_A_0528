using UnityEngine;

public class Player : Actor
{
    private IInput _iInput = null;
    private Vector2Int _position = new Vector2Int(0,0);
    private int _level = 1;
    private int _EXP = 0;
    private IActor.Dir _lastDirection = IActor.Dir.None;

    private void SetProvider(InputProvider inputProvider)
    {
        _iInput = inputProvider;
    }

    public void SetPlayerPos(Vector2Int pos)
    {
        _position = pos;
        transform.position = new Vector3(GetPlayerPos().x, GetPlayerPos().y, 0);
        PlayersCamera.Instance.SetPosition(GetPlayerPos());
    }

    public Vector2Int GetPlayerPos()
    {
        return _position;
    }

    public void Init()
    {
        SetProvider(new InputProvider());
        _HP = _maxHP;
    }

    public void PlayerUpdate()
    {
        if (_iInput.GetAction())
        {
            if (UseStairs())
                return;
        }

        IActor.Dir dir = IActor.Dir.None;
        if (_iInput.GetUp())
        {
            Debug.Log("Up");
            dir = IActor.Dir.Up;
            _lastDirection = IActor.Dir.Up;
        }
        else if (_iInput.GetLeft())
        {
            Debug.Log("Left");
            dir = IActor.Dir.Left;
            _lastDirection = IActor.Dir.Left;
        }
        else if (_iInput.GetRight())
        {
            Debug.Log("Right");
            dir = IActor.Dir.Right;
            _lastDirection = IActor.Dir.Right;
        }
        else if (_iInput.GetDown())
        {
            Debug.Log("Down");
            dir = IActor.Dir.Down;
            _lastDirection = IActor.Dir.Down;
        }

        if(dir != IActor.Dir.None)
        {
            if(Move(dir))
            {
                ItemBase item = GameDirector.Instance.GetItem(GetPlayerPos());
                if (item != null)
                {
                    if(item.Effect())
                    {
                        GameDirector.Instance.DeleteItem(item);
                    }
                }

                GameDirector.Instance.SetIsMovedPleyer(true);
            }
        }


        if(_iInput.GetAttack())
        {
            if(Attack(dir))
            {
                GameDirector.Instance.SetIsMovedPleyer(true);
            }
        }
    }

    public override void  Action()
    {

    }

    private bool Attack(IActor.Dir dir)
    {
        Vector2Int checkPos = GetPlayerPos();
        for (int j = 0; j < _attackRange; j++)
        {
            checkPos += GetMoveDirection((int)_lastDirection);

            Enemy enemy = GameDirector.Instance.GetEnemy(checkPos);
            if (enemy != null)
            {
                enemy.AddDamage(_power);
                Debug.Log("PlayersAttack");
                return true;
            }
        }

        return false;
    }

    public void AddDamage(int damage)
    {
        _HP -= damage;

        if (_HP < 1)
        {
            GameDirector.Instance.GameOver();
            _HP = 0;
        }

        UIManager.Instance.SetHPText(_HP, _maxHP);
    }

    public bool Heal(int heal)
    {
        if (_HP == _maxHP)
            return false;

        _HP += heal;
        if (_maxHP <= _HP)
            _HP = _maxHP;
        UIManager.Instance.SetHPText(_HP, _maxHP);

        return true;
    }
    public int GetHP()
    {
        return _HP;
    }

    public int GetMaxHP()
    {
        return _maxHP;
    }

    public void AddEXP(int exp)
    {
        _EXP += exp;
        while(true)
        {
            if (100 <= _EXP)
            {
                _EXP -= 100;
                LevelUp();
            }
            else break;
        }
    }

    private void LevelUp()
    {
        _level++;
        MaskController.Instance.ChangeView(_level);
        UIManager.Instance.SetLevelText(_level);
    }

    public int GetLevel()
    {
        return _level;
    }

    private bool Move(IActor.Dir dir)
    {
        Vector2Int movedPos = GetPlayerPos();
        movedPos += GetMoveDirection((int)dir);


        if (GameDirector.Instance.IshitWall(movedPos) || GameDirector.Instance.IsHitEnemies(movedPos))
            return false;
        else
        {
            SetPlayerPos(movedPos);
            return true;
        }
    }

    private bool UseStairs()
    {
        if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(GetPlayerPos()) == RandomDungeonWithBluePrint.Map.TileType.Stairs)
        {
            GameDirector.Instance.NextFloor();
            return true;
        }
        else
            return false;
    }
}
