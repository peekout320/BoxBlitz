using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;


/// <summary>
/// UI�ŕ\������{�^���Ɋւ��鏈��
/// </summary>
public class UI_Model : MonoBehaviour
{
    //ATB�Q�[�W�̐��l���ύX�̓s�xUI�ɔ��f�����邽�߂̕ϐ�
    //�U���핪��currentATB��z��ɕێ�����
    public FloatReactiveProperty[] currentAtb ;

    private const int maxAtb = 1;�@//ATB�Q�[�W��MAX�l

    [SerializeField]
    private float plusAtb = 0.2f;   //ATB�Q�[�W�̉��Z�l

    [SerializeField]
    private Button[] attackButton;

    [SerializeField]
    private AttackManager attackManager;

    [SerializeField]
    private CharacterStatus player;

    private void Start()
    {
        for (int i = 0; i < currentAtb.Length; i++)
        {
            int index = i;

            IncreaseAtbGauge(index);
            ActiveAttackButton(index);

            attackButton[index].onClick.AddListener(async () => await PushAttackButton(index));
        }
    }

    /// <summary>
    /// ATB�Q�[�W(���܂�����U���\�ɂȂ�Q�[�W)�����Z����
    /// </summary>
    private void IncreaseAtbGauge(int attackIndex)
    {
       // currentAtb��maxAtb�ȉ��̏ꍇ�A currentAtb��plusAtb�̒l�����Z���ꑱ����
        Observable.EveryUpdate()
            .Where(_ => currentAtb[attackIndex].Value < maxAtb)
            .Subscribe(_ => currentAtb[attackIndex].Value +=attackManager.attackList[attackIndex].attackInterval * Time.deltaTime)
            .AddTo(this);
    }

    /// <summary>
    /// ATB�Q�[�W��MAX�ɂȂ�����U���{�^�����A�N�e�B�u�ɂ��A�A�j���[�V������������
    /// </summary>
    private void ActiveAttackButton(int attackIndex)
    {
        // currentAtb��maxAtb�ȏ�ɂȂ�����A�j���[�V�������AattackButton���A�N�e�B�u��Ԃɂ���
        currentAtb[attackIndex]
            .Select(x => x >= maxAtb)�@ //��(currentAtb�̒l)��maxAtb�ȏ�ɂȂ����炘��true��Ԃ�
            .Do(x => {
                 if (x)�@//x��true�Ȃ�
                 {
                     DoTweenActions.ScaleUpAndDown(attackButton[attackIndex].transform, 0.2f); �@//�A�j���[�V����
                 }
            })
            .SubscribeToInteractable(attackButton[attackIndex])�@//�{�^�����A�N�e�B�u
            .AddTo(this);
    }

    /// <summary>
    /// �A�^�b�N�{�^�����������Ƃ��̏���
    /// </summary>
     private async UniTask PushAttackButton(int attackIndex)
    {
        Debug.Log("�U���J�n");

        //attackList��attackIndex�Ԗڂ�StartAttack���\�b�h���Ăяo��
        attackManager.attackList[attackIndex].StartAttack(player.attackAnimator);

        attackButton[attackIndex].interactable = false;

        await UniTask.Delay(3000);

        currentAtb[attackIndex].Value = 0f;

    }

    private void ReloadCount()
    {

    }
}
