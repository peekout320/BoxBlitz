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
        // 攻撃を開始
        await OnAttackAsync();
    }

    /// <summary>
    /// 任意の攻撃アニメーションを呼び出す
    /// </summary>
    /// <param name="attackName"></param>
    private void StartAttack(string attackName)
    {
        if (!attackAnimator) return;
        attackAnimator.SetTrigger(attackName);
    }

    /// <summary>
    /// 一定の間隔で攻撃アニメーションを開始する
    /// </summary>
    /// <returns></returns>
    private async UniTask OnAttackAsync()
    {
        while (true)
        {
            // attackNameの配列からランダムで選ぶための数値を決める
            int attackNumber = UnityEngine.Random.Range(0, attackName.Length);

            // 攻撃の処理を行う
            StartAttack(attackName[attackNumber]);

            // attackIntervalで指定した数値待機する。ConfigureAwait(PlayerLoopTiming.Update)でループが解除されないようにする。
            await UniTask.Delay(TimeSpan.FromSeconds(attackInterval)).ConfigureAwait(PlayerLoopTiming.Update);
        }
    }
}
