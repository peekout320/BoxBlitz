using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataSO", menuName = " Create CharacterDataSO")]
public class CharacterDataSO : ScriptableObject
{
    public List<CharacterData> objrctDataList = new List<CharacterData>();
}

[System.Serializable]
public class CharacterData
{
    public string name;

    public int hp;

    public float speed;
}