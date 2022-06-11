using UnityEngine;

public class PlayersCamera : SingletonMonoBehaviour<PlayersCamera>
{
    private Vector3 _offset = new Vector3(0.5f, 0.5f);
    private Vector3 _position = new Vector3();
    public void SetPosition(Vector2Int pos)
    {
        _position.x = pos.x;
        _position.y = pos.y;
        _position.z = -10;

        transform.position = _position + _offset;
    }
}
