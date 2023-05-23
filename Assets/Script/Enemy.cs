using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Enemy : CharacterStatus
{
    [SerializeField]
    private Attack_Straight attackStraight;
    public Attack_Straight AttackStraight { get => attackStraight; }

    [SerializeField]
    private Attack_Hook attackHook;
    public Attack_Hook AttackHook { get => attackHook; }

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
            // attackList���烉���_���ōU���p�^�[����I�Ԃ��߂̐��l�����߂�
            int attackNumber = UnityEngine.Random.Range(0, attackManager.attackList.Count);

            Debug.Log("�U���p�^�[��"  +  attackNumber);

            // �U���̏������s��
            if (attackManager.attackList == null) return;
            attackManager.attackList[attackNumber].StartAttack();

            // attackInterval�Ŏw�肵���b���ҋ@����B
            await UniTask.Delay(TimeSpan.FromSeconds(attackManager.attackList[attackNumber].attackInterval));
        }
    }
}
