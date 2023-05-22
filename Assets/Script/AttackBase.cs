using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class AttackBase : MonoBehaviour
{
    [SerializeField]
    float attackInterval = 3f;  

    [SerializeField]
    private string[] attackName;

    [SerializeField]
    private Animator attackAnimator;

    private async UniTask Start()
    {
        // �U�����J�n
        await OnAttackAsync();
    }

    /// <summary>
    /// �C�ӂ̍U���A�j���[�V�������Ăяo��
    /// </summary>
    /// <param name="attackName"></param>
    private void StartAttack(string attackName)
    {
        if (!attackAnimator) return;
        attackAnimator.SetTrigger(attackName);
    }

    /// <summary>
    /// ���̊Ԋu�ōU���A�j���[�V�������J�n����
    /// </summary>
    /// <returns></returns>
    private async UniTask OnAttackAsync()
    {
        while (true)
        {
            // attackName�̔z�񂩂烉���_���őI�Ԃ��߂̐��l�����߂�
            int attackNumber = UnityEngine.Random.Range(0, attackName.Length);

            // �U���̏������s��
            StartAttack(attackName[attackNumber]);

            // attackInterval�Ŏw�肵�����l�ҋ@����BConfigureAwait(PlayerLoopTiming.Update)�Ń��[�v����������Ȃ��悤�ɂ���B
            await UniTask.Delay(TimeSpan.FromSeconds(attackInterval)).ConfigureAwait(PlayerLoopTiming.Update);
        }
    }
}
