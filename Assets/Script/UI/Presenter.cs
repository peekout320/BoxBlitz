using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    private UI_Model uiModel;

    [SerializeField]
    private UI_View uiView;

    private void Start()
    {
        uiModel.currentAtb
            .Subscribe(x => uiView.ViewAtbGauge(x));      
    }
}
