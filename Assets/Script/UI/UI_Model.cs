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

        attackButton.onClick.AddListener(() => PushAttackButton());
    }

    /// <summary>
    /// ATB�Q�[�W(���܂�����U���\�ɂȂ�Q�[�W)�����Z����
    /// </summary>
    private void IncreaseAtbGauge()
    {
       // currentAtb��maxAtb�ȉ��̏ꍇ�A currentAtb��plusAtb�̒l�����Z���ꑱ����
        Observable.EveryUpdate()
            .Where(_ => currentAtb.Value < maxAtb)
            .Subscribe(_ => currentAtb.Value += plusAtb * Time.deltaTime)
            .AddTo(this);
    }

    /// <summary>
    /// ATB�Q�[�W��MAX�ɂȂ�����U���{�^�����A�N�e�B�u�ɂ��A�A�j���[�V������������
    /// </summary>
    private void ActiveAttackButton()
    {
        // currentAtb��maxAtb�ȏ�ɂȂ�����A�j���[�V�������AattackButton���A�N�e�B�u��Ԃɂ���
        currentAtb
            .Select(x => x >= maxAtb)�@ //��(currentAtb�̒l)��maxAtb�ȏ�ɂȂ����炘��true��Ԃ�
            .Do(x => {
                 if (x)�@//x��true�Ȃ�
                 {
                     DoTweenActions.ScaleUpAndDown(attackButton.transform, 0.2f); �@//�A�j���[�V����
                 }
            })
            .SubscribeToInteractable(attackButton)�@//�{�^�����A�N�e�B�u
            .AddTo(this);
    }

    /// <summary>
    /// �A�^�b�N�{�^�����������Ƃ��̏���
    /// </summary>
    private void PushAttackButton()
    {
        Debug.Log("�U���J�n");

        attackButton.interactable = false;

        currentAtb.Value = 0f;
    }
}
