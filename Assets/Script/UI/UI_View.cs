using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UI_View : MonoBehaviour
{
    [SerializeField]
    private Image atbGauge;

    public void ViewAtbGauge(float atbValue)
    {
        atbGauge.fillAmount = atbValue;
    }
}
