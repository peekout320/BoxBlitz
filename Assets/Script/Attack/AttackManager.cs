using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    //シーンにキャラクターを生成したときにattackListに攻撃パターンを追加する
    public List<AttackBase> attackList = new List<AttackBase>();
}
