using UnityEngine;
using DG.Tweening;

public class DoTweenActions
{
    public static void ScaleUpAndDown(Transform target, float duration)
    {
        // �T�C�Y��{�ɂ���
        target.DOScale(2f, duration)
            .SetEase(Ease.InOutSine) // �C�[�W���O�̐ݒ�
            .OnComplete(() =>
            {
                // ���̃T�C�Y�ɖ߂�
                target.DOScale(1f, 0.5f)
                    .SetEase(Ease.OutBounce);
            });
    }
}