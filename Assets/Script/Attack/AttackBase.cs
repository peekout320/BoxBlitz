using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// �S��ނ̍U���ɑ΂���e�N���X�B�d������ϐ��A���\�b�h���q�N���X�֌p������B
/// </summary>
public abstract class AttackBase : MonoBehaviour
{
    //�p���p�����o�ϐ�
    [SerializeField]
    protected string attackName;

    [SerializeField]
    protected float attackPower;

    [SerializeField]
    public float attackInterval;

    [SerializeField]
    protected Animator attackAnimator;


    /// <summary>
    /// attackName�Ŏw�肵���U���A�j���[�V���������s����B�q�N���X�Ɍp���B
    /// </summary>
    /// <param name="attackName"></param>
    public virtual void StartAttack()
    {
        if (!attackAnimator) return;
        attackAnimator.SetTrigger(attackName);
    }
}
