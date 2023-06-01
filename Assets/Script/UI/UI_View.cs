using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UI_View : MonoBehaviour
{
    [SerializeField]
    private Image[] atbGauge;

    //ATBƒQ[ƒW‚Ì’l‚ğUI‚É”½‰f‚³‚¹‚é
    public void ViewAtbGauge(float atbValue,int attackIndex)
    {
        atbGauge[attackIndex].fillAmount = atbValue;
    }
}
