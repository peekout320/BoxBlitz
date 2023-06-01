using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AttackBaseを継承し攻撃の1つの ”アッパー” を実行するクラス
/// プロパティをインスペクター上で設定する仕様にすると、子クラスのスクリプト上で内容が視認できなくなるので、今回はコンストラクタで初期化する。
/// </summary>
public class Attack_Upper : AttackBase
{
    //コンストラクタ
    public Attack_Upper()
    {
        attackName = "Upper";
        attackPower = 5f;
        attackInterval = 0.4f;
    }

    /// <summary>
    /// 攻撃を開始するクラスを継承
    /// </summary>
    public override void StartAttack(Animator animator)
    {
        base.StartAttack(animator);
    }
}
