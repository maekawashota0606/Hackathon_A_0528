using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField,Header("�J�n���W")]
    private Vector2 _startPlayerPos;                //�J�n���̍��W
    private PlayerStatus _playerStatus;
    private Vector2 _playerPos;                     //���݂̈ʒu
    private Vector3 _nextPos;                       //���̈ړ�����m�ۂ�����
    private TestMap _testMap;
    [SerializeField]
    private bool _isMoving = false;                 //�ړ����͑�����󂯕t���Ȃ��悤�ɂ�����
    private void Awake()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _testMap = GameObject.Find("Map").GetComponent<TestMap>();  //��
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
        #region �΂�
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

        #region �㉺���E
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
