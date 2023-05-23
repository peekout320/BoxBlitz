using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SOデータをどこからでも呼び出せるように作成したシングルトン
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