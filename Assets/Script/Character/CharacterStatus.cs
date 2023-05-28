using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerクラスとEnemyクラスへ継承するキャラクターのパラメータ
/// </summary>
public class CharacterStatus : MonoBehaviour
{
    public string CharaName;

    public CharacterStatus obj;

    public int hp;

    public float speed;

    public Animator attackAnimator;
}
