using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private Transform enemyTran;

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryFixedUpdate()
            .Subscribe(_ =>
            {
                MovePlayer();
                LookEnemy();
            })
            .AddTo(this);
    }

    /// <summary>
    /// プレイヤーを方向キーで移動。Rigidbodyを使用。
    /// </summary>
    private void MovePlayer()
    {
        if (!Input.anyKey) return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Debug.Log("Horizontal" + x);
        Debug.Log("Vertical" + z);

        var movement = new Vector3(x, 0, z) * speed * Time.deltaTime;

        this.transform.position += transform.TransformDirection(movement);

        //Rigidbodyでの移動
        //rigid.AddForce(transform.TransformDirection(movement) * speed);

        //物理無視移動
       // rigid.MovePosition(rigid.position + transform.TransformDirection(movement) );

    }

    /// <summary>
    /// 常に敵の方向を見る
    /// </summary>
    private void LookEnemy()
    {
        this.transform.LookAt(enemyTran);
    }
}
