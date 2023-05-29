using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UI_Model : MonoBehaviour
{
    public ReactiveProperty<float>currentAtb = new FloatReactiveProperty();

    private const int maxAtb = 1;
    [SerializeField]
    private float plusAtb = 0.2f;

    [SerializeField]
    private Button attackButton;

    private void Start()
    {
        IncreaseAtbGauge();
        ActiveAttackButton();
    }

    /// <summary>
    ///currentAtb��maxAtb�ȉ��̏ꍇ�A currentAtb��plusAtb�̒l�����Z���ꑱ����
    /// </summary>
    private void IncreaseAtbGauge()
    {
        Observable.EveryUpdate()
            .Where(_ => currentAtb.Value < maxAtb)
            .Subscribe(_ => currentAtb.Value += plusAtb * Time.deltaTime)
            .AddTo(this);
    }

    /// <summary>
    /// currentAtb��maxAtb�ȏ�ɂȂ�����attackButton���A�N�e�B�u��Ԃɂ���
    /// </summary>
    private void ActiveAttackButton()
    {
        currentAtb
            .Select(atb => atb >= maxAtb)
            .SubscribeToInteractable(attackButton)
            .AddTo(this);
    }
}
