using UnityEngine;
interface IActor
{
    void Action();     // ���炩�̍s�������s����B�s�����[�V�����̏I���܂ŏ�����ҋ@�����邽�߂�Task��Ԃ�

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