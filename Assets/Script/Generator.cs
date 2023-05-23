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
    /// �G�𐶐�����
    /// </summary>
    /// <param name="index"></param>
    public void GenerateEnemy(int index)
    {
        Debug.Log("index" + index);
        //SO(�X�N���v�^�u���I�u�W�F�N�g)�f�[�^�ɓo�^���Ă���CharacterStatus�^�Ő������AEnemy�N���X��GetComponent����B
        CharacterStatus enemy = Instantiate(DataBaseManager.instance.characterDataSO.characterDataList[index].obj, enemyTran, true);

        Enemy enemyInfo = enemy.GetComponent<Enemy>();

        //AttackManager�𐶐�����enemy�ɕt�^
        enemyInfo.SetupAttackManager(attackManager);

        //�p�����[�^��o�^
        SettingParameter(enemy,index);

        //�U���p�^�[����o�^
        attackManager.attackList.Add(enemyInfo.AttackStraight);
        attackManager.attackList.Add(enemyInfo.AttackHook);
    }

    /// <summary>
    /// �L�����N�^�[���C���X�^���X�������Ƃ���SO�f�[�^���p�����[�^��t�^
    /// </summary>
    /// <param name="chara"></param>
    /// <param name="index"></param>
    private void SettingParameter(CharacterStatus chara,int index)
    {
        chara.CharaName = DataBaseManager.instance.characterDataSO.characterDataList[index].charaName;
        chara.obj = DataBaseManager.instance.characterDataSO.characterDataList[index].obj;
        chara.hp = DataBaseManager.instance.characterDataSO.characterDataList[index].hp;
        chara.speed = DataBaseManager.instance.characterDataSO.characterDataList[index].speed;
    }
}
