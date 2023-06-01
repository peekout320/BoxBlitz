using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AttackBase���p�����U�����1�� �h�t�b�N�h �����s����N���X
/// �v���p�e�B���C���X�y�N�^�[��Őݒ肷��d�l�ɂ���ƁA�q�N���X�̃X�N���v�g��Ŏ��F�ł��Ȃ��Ȃ�̂ŁA����̓R�[�h��ŏ����l��ݒ肷��B
/// </summary>
public class Attack_Hook : AttackBase
{
    //�R���X�g���N�^
    public Attack_Hook()
    {
        attackName = "Hook";
        attackPower = 3f;
        attackInterval = 0.3f;
    }

    /// <summary>
    /// �U�����J�n����N���X���p��
    /// </summary>
    public override void StartAttack(Animator animator)
    {
        base.StartAttack(animator);
    }
}
