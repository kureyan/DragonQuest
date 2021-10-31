using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Playerの1マス移動

    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;

    Animator animator;

    //壁判定のLayer
    [SerializeField] LayerMask solidObjectsLayer;
    //エンカウント判定のLayer
    [SerializeField] LayerMask encountLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    
    void Update()
    {
        if(!isMoving)
        {
            //キーボードの入力方向に動く
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //斜め移動
            if (input.x != 0) 
            {
                input.y = 0;
            }

            //入力があったら
            if (input != Vector2.zero)
            {
                //向きを変えたい
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                Vector2 targetPos = transform.position;
                targetPos += input;
                if(IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    //コルーチンを使って徐々に目的地に近づける
    IEnumerator Move(Vector3 targetPos)
    {
        //移動中は入力を受け付けたくない
        isMoving = true;

        //targetPosとの差があるなら繰り返す
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //targetPosに近づける
            transform.position = Vector3.MoveTowards(
                transform.position, //現在の場所
                targetPos,          //目的地
                moveSpeed * Time.deltaTime
                );
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
        CheckForEncounters();
    }

    //targetPosに移動可能かを調べる関数
    bool IsWalkable(Vector2 targetPos)
    {
        //targetPosに半径0.1fの円のRayを飛ばして、ぶつからなかった
        return Physics2D.OverlapCircle(targetPos, 0.1f,solidObjectsLayer) == false;
    }

    //自分の場所から、円のRayを飛ばして、エンカウントLayerに当たったら、ランダムエンカウントする
    void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f, encountLayer))
        {
            //ランダムエンカウント
            if (Random.Range(0,100) < 10)
            {
                //Random.Range(0,100):0～90までのどれかの数字が出る
                //10より小さい数字は0～9までの10個:10%の確率
                //10以上の数字は10～99までの90個
                Debug.Log("モンスターに遭遇");
            }

        }

    }

}