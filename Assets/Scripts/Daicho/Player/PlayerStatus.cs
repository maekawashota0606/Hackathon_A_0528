using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public Vector2 PlayerPos = Vector2.zero; //���݂̃v���C���[���W
    [Header("�v���C���[�̗̑�")]
    public int Hp;
    [Header("�v���C���[�̈ړ����x")]
    public int MoveSpeed;
    /// <summary>
    /// �񕜂���֐�
    /// </summary>
    public void Heal()
    {
        var healNum = 0;    //�񕜗ʂ͒������ׂ� �񕜗ʂ������ɗ^���Ă��悵

        Hp += healNum;
    }
}
