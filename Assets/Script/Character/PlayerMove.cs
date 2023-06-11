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
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                MovePlayer();
                LookEnemy();
            })
            .AddTo(this);
    }

    /// <summary>
    /// �v���C���[������L�[�ňړ��BRigidbody���g�p�B
    /// </summary>
    private void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Debug.Log("Horizontal" + x);
        Debug.Log("Vertical" + z);

        var movement = new Vector3(x, 0, z) * speed * Time.deltaTime;

        this.transform.position += transform.TransformDirection(movement);

        //Rigidbody�ł̈ړ�
        //rigid.AddForce(transform.TransformDirection(movement) * speed);

    }

    /// <summary>
    /// ��ɓG�̕���������
    /// </summary>
    private void LookEnemy()
    {
        this.transform.LookAt(enemyTran);
    }
}
