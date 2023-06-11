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
        //指定のコライダーがプレイヤーと接触したときにMovementEnemy()を呼び出す
        col.OnTriggerStayAsObservable()
      　　　.Where(collision => collision.gameObject.TryGetComponent(out Player player))
     　　　 .Subscribe(_ =>
    　　　  {
                   Debug.Log("player確認");
        　　　  MovementEnemy();
      　　　});
    }

    /// <summary>
    /// NavMeshAgentでプレイヤーに向かって移動する
    /// </summary>
    private void MovementEnemy()
    {
        if (!player) return;
        Vector3 playerTran = player.position; //NavMeshAgent.Move()の引数がVector3型なので入れ直す

        Debug.Log("移動開始");
        //nav.Move(playerTran);
        nav.destination = playerTran;
    }
}
