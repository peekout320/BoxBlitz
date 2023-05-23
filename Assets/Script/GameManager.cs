using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageLevel = 1;

    [SerializeField]
    private Generator generator;

    private void Start()
    {
        //�X�e�[�W���x���ɍ��킹�ēG�𐶐�
        generator.GenerateEnemy(stageLevel);
    }
}
