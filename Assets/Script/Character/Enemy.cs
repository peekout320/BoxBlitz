using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Enemy : CharacterStatus
{
    private AttackManager attackManager;

    async void Start()
    {
        await OnAttackAsync();
    }

    /// <summary>
    /// �L�����N�^�[��������AttackManager���擾���邽�߂̃��\�b�h
    /// </summary>
    /// <param name="attackManager"></param>
    public void SetupAttackManager(AttackManager attackManager)
    {
        this.attackManager = attackManager;
    }

    /// <summary>
    ///  ���̊Ԋu�Ŏ����I�Ƀ����_���ōU������B
    /// </summary>
    /// <returns></returns>
    public async UniTask OnAttackAsync()
    {
        while (true)
        {
            // attackList���烉���_���ōU����I�Ԃ��߂̐��l
            int attackNumber = UnityEngine.Random.Range(0, attackManager.attackList.Count);

            Debug.Log("�U���p�^�[��"  +  attackNumber);

            // �U���̏������s��
            if (attackManager.attackList == null) return;
            attackManager.attackList[attackNumber].StartAttack(attackAnimator);

            // attackInterval�Ŏw�肵���b���ҋ@����B
            await UniTask.Delay(TimeSpan.FromSeconds(attackManager.attackList[attackNumber].attackInterval));
        }
    }
}
