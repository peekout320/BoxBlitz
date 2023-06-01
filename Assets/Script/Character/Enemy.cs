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
    /// キャラクター生成時にAttackManagerを取得するためのメソッド
    /// </summary>
    /// <param name="attackManager"></param>
    public void SetupAttackManager(AttackManager attackManager)
    {
        this.attackManager = attackManager;
    }

    /// <summary>
    ///  一定の間隔で自動的にランダムで攻撃する。
    /// </summary>
    /// <returns></returns>
    public async UniTask OnAttackAsync()
    {
        while (true)
        {
            // attackListからランダムで攻撃を選ぶための数値
            int attackNumber = UnityEngine.Random.Range(0, attackManager.attackList.Count);

            Debug.Log("攻撃パターン"  +  attackNumber);

            // 攻撃の処理を行う
            if (attackManager.attackList == null) return;
            attackManager.attackList[attackNumber].StartAttack(attackAnimator);

            // attackIntervalで指定した秒数待機する。
            await UniTask.Delay(TimeSpan.FromSeconds(attackManager.attackList[attackNumber].attackInterval));
        }
    }
}
