using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// ４種類の攻撃に対する親クラス。重複する変数、メソッドを子クラスへ継承する。
/// </summary>
public abstract class AttackBase : MonoBehaviour
{
    //継承用メンバ変数
    [SerializeField]
    protected string attackName;

    [SerializeField]
    protected float attackPower;

    [SerializeField]
    public float attackInterval;


    /// <summary>
    /// attackNameで指定した攻撃アニメーションを実行する。子クラスに継承。
    /// </summary>
    /// <param name="attackName"></param>
    public virtual void StartAttack(Animator attackAnimator)
    {
        if (!attackAnimator) return;
        attackAnimator.SetTrigger(attackName);
    }
}
