using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string Name;
    public int Level;
    public int HP;
    public int MP;


    //使える呪文
    public List<Spell> Spells { get; set; }


    //覚える呪文一覧
    [SerializeField] List<LearnableSpell> LearnableSpells;

    //public List<LearnableSpell> LearnableSpells { get => LearnableSpells; }

    //Playerの1マス移動

    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;

    Animator animator;
    LearnableSpell leanablespell;

    //壁判定のLayer
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    //エンカウント判定のLayer
    [SerializeField] LayerMask encountLayer;
    //シーン移動判定のLayer
    [SerializeField] LayerMask TransitionAreaLayer;


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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    //interactableLayerがついているもの(NPC)に向かってZボタンを押したらログを出す
    //Playerの向いている方からRayを飛ばす
    //RayにぶつかったオブジェクトがNPCならログを出す
    void Interact()
    {
        //向いている方向
        Vector3 faceDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        //干渉する場所(現在の場所から向いてる方向を足すからVector3)
        Vector3 interactPos = transform.position + faceDirection;

        //干渉する場所にRayを飛ばす
        Collider2D collider2D = Physics2D.OverlapCircle(interactPos, 0.1f, interactableLayer);
        if (collider2D)
        {
            collider2D.GetComponent<NPC>().Interact();
        }
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
        CheckForArea();
        CheckForEncounters();
    }

    //targetPosに移動可能かを調べる関数
    bool IsWalkable(Vector2 targetPos)
    {
        //targetPosに半径0.1fの円のRayを飛ばして、ぶつからなかった
        return Physics2D.OverlapCircle(targetPos, 0.1f,solidObjectsLayer | interactableLayer) == false;
    }

    //自分の場所から、円のRayを飛ばして、エンカウントLayerに当たったら、ランダムエンカウントする
    void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f, encountLayer))
        {
            //ランダムエンカウント
            if (UnityEngine.Random.Range(0,100) < 10)
            {
                //Random.Range(0,100):0～90までのどれかの数字が出る
                //10より小さい数字は0～9までの10個:10%の確率
                //10以上の数字は10～99までの90個
                Debug.Log("モンスターに遭遇");
            }

        }

    }
    //自分の場所から、円のRayを飛ばして、シーン移動Layerに当たったら、シーンを切り替える
    void CheckForArea()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)input, 0.1f, TransitionAreaLayer);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        if (hit.collider)
        {
            //Debug.Log(hit.collider.gameObject.name);
            Scene obj = GameObject.Find(hit.collider.gameObject.name).GetComponent<Scene>();
            obj.LoadArea();
        }
    }

    /*void LevelUp(int pLevel)
    {
        level = pLevel;

        //使える呪文の設定;覚える呪文のレベル以上なら、Spellsに追加
        foreach (LearnableSpell spell in LearnableSpells)
        {
            if (pLevel >= leanablespell.Level)
            {
                //呪文を覚える
                Spells.Add(new Spell(leanablespell.Base));
            }
                
        }

    }*/
}

//覚える呪文クラス:どのレベルで何を覚えるのか
[Serializable]
public class LearnableSpell
{
    //ヒエラルキーで設定する
    [SerializeField] SpellBase _base;
    [SerializeField] int level;

    public SpellBase Base { get => _base; }
    public int Level { get => level; }
}

