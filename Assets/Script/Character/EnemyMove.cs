using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent nav;

    [SerializeField]
    Transform player;

    [SerializeField]
    Collider col;

    private void Start()
    {
        //�w��̃R���C�_�[���v���C���[�ƐڐG�����Ƃ���MovementEnemy()���Ăяo��
        col.OnTriggerStayAsObservable()
      �@�@�@.Where(collision => collision.gameObject.TryGetComponent(out Player player))
     �@�@�@ .Subscribe(_ =>
    �@�@�@  {
                   Debug.Log("player�m�F");
        �@�@�@  MovementEnemy();
      �@�@�@});
    }

    /// <summary>
    /// NavMeshAgent�Ńv���C���[�Ɍ������Ĉړ�����
    /// </summary>
    private void MovementEnemy()
    {
        if (!player) return;
        Vector3 playerTran = player.position; //NavMeshAgent.Move()�̈�����Vector3�^�Ȃ̂œ��꒼��

        Debug.Log("�ړ��J�n");
        //nav.Move(playerTran);
        nav.destination = playerTran;
    }
}
