using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UI_View : MonoBehaviour
{
    [SerializeField]
    private Image[] atbGauge;

    //ATB�Q�[�W�̒l��UI�ɔ��f������
    public void ViewAtbGauge(float atbValue,int attackIndex)
    {
        atbGauge[attackIndex].fillAmount = atbValue;
    }
}
