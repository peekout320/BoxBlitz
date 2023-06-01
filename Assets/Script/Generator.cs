using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private Transform enemyTran;

    [SerializeField]
    AttackManager attackManager;

    /// <summary>
    /// 敵を生成する
    /// </summary>
    /// <param name="index"></param>
    public void GenerateEnemy(int index)
    {
        Debug.Log("index" + index);
        //SO(スクリプタブルオブジェクト)データに登録しているCharacterStatus型で生成し、EnemyクラスをGetComponentする。
        CharacterStatus enemy = Instantiate(DataBaseManager.instance.characterDataSO.characterDataList[index].obj, enemyTran, true);

        Enemy enemyInfo = enemy.GetComponent<Enemy>();

        //AttackManagerを付与
        enemyInfo.SetupAttackManager(attackManager);

        //パラメータを登録
        SettingParameter(enemy,index);
    }

    /// <summary>
    /// キャラクターをインスタンス化したときにSOデータよりパラメータを付与
    /// </summary>
    /// <param name="chara"></param>
    /// <param name="index"></param>
    private void SettingParameter(CharacterStatus chara,int index)
    {
        chara.CharaName = DataBaseManager.instance.characterDataSO.characterDataList[index].charaName;
        chara.hp = DataBaseManager.instance.characterDataSO.characterDataList[index].hp;
        chara.speed = DataBaseManager.instance.characterDataSO.characterDataList[index].speed;
    }
}
