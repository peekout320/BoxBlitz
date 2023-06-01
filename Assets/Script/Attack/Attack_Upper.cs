using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AttackBase���p�����U����1�� �h�A�b�p�[�h �����s����N���X
/// �v���p�e�B���C���X�y�N�^�[��Őݒ肷��d�l�ɂ���ƁA�q�N���X�̃X�N���v�g��œ��e�����F�ł��Ȃ��Ȃ�̂ŁA����̓R���X�g���N�^�ŏ���������B
/// </summary>
public class Attack_Upper : AttackBase
{
    //�R���X�g���N�^
    public Attack_Upper()
    {
        attackName = "Upper";
        attackPower = 5f;
        attackInterval = 0.4f;
    }

    /// <summary>
    /// �U�����J�n����N���X���p��
    /// </summary>
    public override void StartAttack(Animator animator)
    {
        base.StartAttack(animator);
    }
}
