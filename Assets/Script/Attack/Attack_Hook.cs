using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AttackBaseを継承し攻撃種の1つ ”フック” を実行するクラス
/// プロパティをインスペクター上で設定する仕様にすると、子クラスのスクリプト上で視認できなくなるので、今回はコード上で初期値を設定する。
/// </summary>
public class Attack_Hook : AttackBase
{
    //コンストラクタ
    public Attack_Hook()
    {
        attackName = "Hook";
        attackPower = 3f;
        attackInterval = 0.3f;
    }

    /// <summary>
    /// 攻撃を開始するクラスを継承
    /// </summary>
    public override void StartAttack(Animator animator)
    {
        base.StartAttack(animator);
    }
}
