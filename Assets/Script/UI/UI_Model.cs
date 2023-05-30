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
    /// ATBゲージ(溜まったら攻撃可能になるゲージ)を加算する
    /// </summary>
    private void IncreaseAtbGauge()
    {
       // currentAtbがmaxAtb以下の場合、 currentAtbにplusAtbの値が加算され続ける
        Observable.EveryUpdate()
            .Where(_ => currentAtb.Value < maxAtb)
            .Subscribe(_ => currentAtb.Value += plusAtb * Time.deltaTime)
            .AddTo(this);
    }

    /// <summary>
    /// ATBゲージがMAXになったら攻撃ボタンをアクティブにし、アニメーションをおこす
    /// </summary>
    private void ActiveAttackButton()
    {
        // currentAtbがmaxAtb以上になったらアニメーションし、attackButtonをアクティブ状態にする
        currentAtb
            .Select(x => x >= maxAtb)　 //ｘ(currentAtbの値)がmaxAtb以上になったらｘにtrueを返す
            .Do(x => {
                 if (x)　//xがtrueなら
                 {
                     DoTweenActions.ScaleUpAndDown(attackButton.transform, 0.2f); 　//アニメーション
                 }
            })
            .SubscribeToInteractable(attackButton)　//ボタンをアクティブ
            .AddTo(this);
    }

    /// <summary>
    /// アタックボタンを押したときの処理
    /// </summary>
    private void PushAttackButton()
    {
        Debug.Log("攻撃開始");

        attackButton.interactable = false;

        currentAtb.Value = 0f;
    }
}
