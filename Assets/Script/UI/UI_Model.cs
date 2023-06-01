using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;


/// <summary>
/// UIで表示するボタンに関する処理
/// </summary>
public class UI_Model : MonoBehaviour
{
    //ATBゲージの数値が変更の都度UIに反映させるための変数
    //攻撃種分のcurrentATBを配列に保持する
    public FloatReactiveProperty[] currentAtb ;

    private const int maxAtb = 1;　//ATBゲージのMAX値

    [SerializeField]
    private float plusAtb = 0.2f;   //ATBゲージの加算値

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
    /// ATBゲージ(溜まったら攻撃可能になるゲージ)を加算する
    /// </summary>
    private void IncreaseAtbGauge(int attackIndex)
    {
       // currentAtbがmaxAtb以下の場合、 currentAtbにplusAtbの値が加算され続ける
        Observable.EveryUpdate()
            .Where(_ => currentAtb[attackIndex].Value < maxAtb)
            .Subscribe(_ => currentAtb[attackIndex].Value +=attackManager.attackList[attackIndex].attackInterval * Time.deltaTime)
            .AddTo(this);
    }

    /// <summary>
    /// ATBゲージがMAXになったら攻撃ボタンをアクティブにし、アニメーションをおこす
    /// </summary>
    private void ActiveAttackButton(int attackIndex)
    {
        // currentAtbがmaxAtb以上になったらアニメーションし、attackButtonをアクティブ状態にする
        currentAtb[attackIndex]
            .Select(x => x >= maxAtb)　 //ｘ(currentAtbの値)がmaxAtb以上になったらｘにtrueを返す
            .Do(x => {
                 if (x)　//xがtrueなら
                 {
                     DoTweenActions.ScaleUpAndDown(attackButton[attackIndex].transform, 0.2f); 　//アニメーション
                 }
            })
            .SubscribeToInteractable(attackButton[attackIndex])　//ボタンをアクティブ
            .AddTo(this);
    }

    /// <summary>
    /// アタックボタンを押したときの処理
    /// </summary>
     private async UniTask PushAttackButton(int attackIndex)
    {
        Debug.Log("攻撃開始");

        //attackList内attackIndex番目のStartAttackメソッドを呼び出す
        attackManager.attackList[attackIndex].StartAttack(player.attackAnimator);

        attackButton[attackIndex].interactable = false;

        await UniTask.Delay(3000);

        currentAtb[attackIndex].Value = 0f;

    }

    private void ReloadCount()
    {

    }
}
