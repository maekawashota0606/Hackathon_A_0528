using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField,Header("開始座標")]
    private Vector2 _startPlayerPos;                //開始時の座標
    private PlayerStatus _playerStatus;
    private Vector2 _playerPos;                     //現在の位置
    private Vector3 _nextPos;                       //次の移動先を確保するやつ
    private TestMap _testMap;
    [SerializeField]
    private bool _isMoving = false;                 //移動中は操作を受け付けないようにするやつ
    private void Awake()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _testMap = GameObject.Find("Map").GetComponent<TestMap>();  //仮
    }
    private void Start()
    {
        _playerStatus.PlayerPos = _startPlayerPos;
    }

    private void Update()
    {
        PlayeMove();
        if(_isMoving)
        {
            if ((_nextPos - transform.localPosition).sqrMagnitude > Mathf.Epsilon)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, _nextPos, _playerStatus.MoveSpeed * Time.deltaTime);
            }
            if(transform.localPosition == _nextPos)
            {
                _isMoving = false;
                _nextPos = _playerPos;
            }
        }
    }

    private void PlayeMove()
    {
        #region 斜め
        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        //{
        //    if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x - 1, (int)_playerStatus.PlayerPos.y - 1] != 2 && !_isMoving)
        //    {
        //        _playerStatus.PlayerPos.x--;
        //        _playerStatus.PlayerPos.y--;
        //        _nextPos = new Vector3(transform.position.x - 1, transform.position.y - 1, 0);
        //        _isMoving = true;
        //    }
        //}
        //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        //{
        //    if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x - 1, (int)_playerStatus.PlayerPos.y + 1] != 2 && !_isMoving)
        //    {
        //        _playerStatus.PlayerPos.x++;
        //        _playerStatus.PlayerPos.y--;
        //        _nextPos = new Vector3(transform.position.x + 1, transform.position.y - 1, 0);
        //        _isMoving = true;
        //    }
        //}
        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        //{
        //    if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x + 1, (int)_playerStatus.PlayerPos.y + 1] != 2 && !_isMoving)
        //    {
        //        _playerStatus.PlayerPos.x++;
        //        _playerStatus.PlayerPos.y--;
        //        _nextPos = new Vector3(transform.position.x + 1, transform.position.y - 1, 0);
        //        _isMoving = true;
        //    }
        //}
        //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        //{
        //    if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x - 1, (int)_playerStatus.PlayerPos.y + 1] != 2 && !_isMoving)
        //    {
        //        _playerStatus.PlayerPos.x++;
        //        _playerStatus.PlayerPos.y++;
        //        _nextPos = new Vector3(transform.position.x + 1, transform.position.y + 1, 0);
        //        _isMoving = true;
        //    }
        //}
        #endregion

        #region 上下左右
        if (!_isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x, (int)_playerStatus.PlayerPos.y - 1] != 2 && !_isMoving)
                {
                    _playerStatus.PlayerPos.y--;
                    _nextPos = new Vector3(transform.position.x, transform.position.y + 1 ,0);
                    _isMoving = true;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x, (int)_playerStatus.PlayerPos.y + 1] != 2 && !_isMoving)
                {
                    _playerStatus.PlayerPos.y++;
                    _nextPos = new Vector3(transform.position.x, transform.position.y - 1, 0);
                    _isMoving = true;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x - 1, (int)_playerStatus.PlayerPos.y] != 2 && !_isMoving)
                {
                    _playerStatus.PlayerPos.x--;
                    _nextPos = new Vector3(transform.position.x - 1, transform.position.y, 0);
                    _isMoving = true;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (_testMap.MapArray[(int)_playerStatus.PlayerPos.x + 1, (int)_playerStatus.PlayerPos.y] != 2 && !_isMoving)
                {
                    _playerStatus.PlayerPos.x++;
                    _nextPos = new Vector3(transform.position.x + 1, transform.position.y, 0);
                    _isMoving = true;
                }
            }
        }
        #endregion
    }
}
