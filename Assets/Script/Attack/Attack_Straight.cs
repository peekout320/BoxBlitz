using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AttackBaseを継承し攻撃の1つの ”ストレート” を実行するクラス
/// プロパティをインスペクター上で設定する仕様にすると、子クラスのスクリプト上で内容が視認できなくなるので、今回はコンストラクタで初期化する。
/// </summary>
public class Attack_Straight : AttackBase
{
    //コンストラクタ
    public Attack_Straight()
    {
        attackName = "Straight";
        attackPower = 3f;
        attackInterval = 0.2f;
    }

    /// <summary>
    /// 攻撃を開始するクラスを継承
    /// </summary>
    public override void StartAttack(Animator animator)
    {
        base.StartAttack(animator);
    }
}
