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
        for (int i = 0; i < uiModel.currentAtb.Length; i++)
        {
            int index = i; @//•Ï”‚É“ü‚ê‚È‚¨‚³‚È‚¢‚ÆƒGƒ‰[‚ª‚Å‚é
            uiModel.currentAtb[index]
                .Subscribe(x => uiView.ViewAtbGauge(x , index));
        }
    }
}
