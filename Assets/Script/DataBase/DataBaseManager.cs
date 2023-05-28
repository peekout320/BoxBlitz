using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO�f�[�^���ǂ�����ł��Ăяo����悤�ɍ쐬�����V���O���g��
/// </summary>
public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    public CharacterDataSO characterDataSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}