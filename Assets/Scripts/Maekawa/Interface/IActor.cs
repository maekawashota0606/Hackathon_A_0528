using UnityEngine;
interface IActor
{
    void Action();     // 何らかの行動を実行する。行動モーションの終わりまで処理を待機させるためにTaskを返す

    Vector2Int MoveUp();
    Vector2Int MoveLeft();
    Vector2Int MoveRight();
    Vector2Int MoveDown();

    enum Dir
    {
        Up,
        Left,
        Right,
        Down,
    };
}