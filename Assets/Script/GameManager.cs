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
        //ステージレベルに合わせて敵を生成
        generator.GenerateEnemy(stageLevel);
    }
}
