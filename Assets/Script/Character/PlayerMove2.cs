using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class PlayerMove2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private Transform enemyTran;

    private Vector3 latestPos;

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                MovePlayer();
                MovementDirection();
            })
            .AddTo(this);
    }

    private void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) return;

        var MoveX = Input.GetAxis("Horizontal");
        var MoveZ = Input.GetAxis("Vertical");

        //移動スピード制限
        //float MoveX = Mathf.Clamp(_horizontal, -limitSpeed, limitSpeed);
        //float MoveZ = Mathf.Clamp(_vertical, -limitSpeed, limitSpeed);

        //Y軸に対する入力をカメラ奥へのベクトルに変換
        var changeVector = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        //力を加える
        //rigidQueri.AddForce(changeVector * new Vector3(MoveX, 0, MoveZ) * speed, ForceMode.VelocityChange);
        transform.position += changeVector * new Vector3(MoveX, 0, MoveZ) * speed;
    }

    private void MovementDirection()
    {
        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;

        diff.y = 0; 　//縦回転しないようにする

        if (diff.magnitude > 0.002f)
        {
            float rotSpeed = 3f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), Time.deltaTime * rotSpeed);
        }
    }
}
