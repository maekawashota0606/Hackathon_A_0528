//using UnityEngine;

///// <summary>
///// �v���C���[��HP���񕜂���A�C�e��
///// </summary>
//public class SampleItem_1 : ItemBase
//{
//    [SerializeField]
//    private int _healPoint = 0;


//#if UNITY_EDITOR
//    // �����m�F�p(�K���ɍ폜���Ă悢)
//    private void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Z))
//            Effect();
//    }
//#endif

//    public override void Effect()
//    {
//        // Example 1
//        // �v���C���[�̉񕜊֐����Ă�(�񕜂̕K�v���Ȃ��Ă��g�p�����)
//        // �ˋ�̉񕜊֐�
//        //Player.Heal(_healPoint);
//        Debug.Log("�񕜃A�C�e�����g�p�����B");
//        // �g���؂�A�C�e���Ȃ炻�̏�Ŕj��(Destroy�͎g�p���Ȃ�)
//        base.Trash();

//        // Example 2
//        // bool�Ŗ߂�l���Q�Ƃ���Ό��ʂ��Ȃ�������(HP�����ɖ��^���������Ȃ�)�ɔj�����Ȃ����Ƃ��ł���
//        //if (Player.Heal(_healPoint))
//        //{
//        //    Debug.Log("�񕜃A�C�e�����g�p�����B");
//        //    // �g�p��A�j��
//        //    base.Trash();
//        //}
//    }
//}
