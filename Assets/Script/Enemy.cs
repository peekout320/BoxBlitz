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
            // attackListからランダムで攻撃パターンを選ぶための数値を決める
            int attackNumber = UnityEngine.Random.Range(0, attackManager.attackList.Count);

            Debug.Log("攻撃パターン"  +  attackNumber);

            // 攻撃の処理を行う
            if (attackManager.attackList == null) return;
            attackManager.attackList[attackNumber].StartAttack();

            // attackIntervalで指定した秒数待機する。
            await UniTask.Delay(TimeSpan.FromSeconds(attackManager.attackList[attackNumber].attackInterval));
        }
    }
}
