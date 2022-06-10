using UnityEngine;

public class Player : Actor
{
    private const int _MAX_HP = 100;
    private int _HP = _MAX_HP;
    private IInput _iInput = null;
    private Vector2Int _playerPos = new Vector2Int(0,0);

    private void SetProvider(InputProvider inputProvider)
    {
        _iInput = inputProvider;
    }

    public void SetPlayerPos(Vector2Int pos)
    {
        _playerPos = pos;
        transform.position = new Vector3(GetNegativePlayerPos().x, GetNegativePlayerPos().y, 0);
    }

    public Vector2Int GetPositivePlayerPos()
    {
        return _playerPos;
    }

    public Vector2Int GetNegativePlayerPos()
    {
        Vector2Int pos = _playerPos;
        pos.y *= -1;
        return pos;
    }


    private void Awake()
    {
        SetProvider(new InputProvider());
    }

    private void Update()
    {
        if (_iInput.GetUp())
            Debug.Log("Up");
        if (_iInput.GetLeft())
            Debug.Log("Left");
        if (_iInput.GetRight())
            Debug.Log("Right");
        if (_iInput.GetDown())
            Debug.Log("Down");
    }

    public void  IAction()
    {

    }

    private bool Attack(IActor.Dir dir)
    {
        Vector2Int move;

        Vector2Int attackPos;

        return true;
    }

    private bool Move(IActor.Dir dir)
    {
        Vector2Int movedPos = GetPositivePlayerPos();
        switch (dir)
        {
            case IActor.Dir.Up:
                movedPos += MoveUp();
                break;
            case IActor.Dir.Left:
                movedPos += MoveLeft();
                break;
            case IActor.Dir.Right:
                movedPos += MoveRight();
                break;
            case IActor.Dir.Down:
                movedPos += MoveDown();
                break;
            default:
                Debug.LogError("error");
                break;
        }

        if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(movedPos) == RandomDungeonWithBluePrint.Map.TileType.Floor)
        {
            //
            SetPlayerPos(movedPos);
            return true;
        }
        else
            return false;
    }

    private bool UseStairs()
    {
        if (RandomDungeonWithBluePrint.Map.Instance.GetTileTipe(GetPositivePlayerPos()) == RandomDungeonWithBluePrint.Map.TileType.Stairs)
        {
            // 
            return true;
        }
        else
            return false;

    }
}
