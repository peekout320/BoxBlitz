using UnityEngine;
using DG.Tweening;

public class DoTweenActions
{
    public static void ScaleUpAndDown(Transform target, float duration)
    {
        // サイズを倍にする
        target.DOScale(2f, duration)
            .SetEase(Ease.InOutSine) // イージングの設定
            .OnComplete(() =>
            {
                // 元のサイズに戻す
                target.DOScale(1f, 0.5f)
                    .SetEase(Ease.OutBounce);
            });
    }
}