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


    //�g�������
    public List<Spell> Spells { get; set; }


    //�o��������ꗗ
    [SerializeField] List<LearnableSpell> LearnableSpells;

    //public List<LearnableSpell> LearnableSpells { get => LearnableSpells; }

    //Player��1�}�X�ړ�

    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;

    Animator animator;
    LearnableSpell leanablespell;

    //�ǔ����Layer
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    //�G���J�E���g�����Layer
    [SerializeField] LayerMask encountLayer;
    //�V�[���ړ������Layer
    [SerializeField] LayerMask TransitionAreaLayer;


    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if(!isMoving)
        {
            //�L�[�{�[�h�̓��͕����ɓ���
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //�΂߈ړ�
            if (input.x != 0) 
            {
                input.y = 0;
            }

            //���͂���������
            if (input != Vector2.zero)
            {
                //������ς�����
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

    //interactableLayer�����Ă������(NPC)�Ɍ�������Z�{�^�����������烍�O���o��
    //Player�̌����Ă��������Ray���΂�
    //Ray�ɂԂ������I�u�W�F�N�g��NPC�Ȃ烍�O���o��
    void Interact()
    {
        //�����Ă������
        Vector3 faceDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        //������ꏊ(���݂̏ꏊ��������Ă�����𑫂�����Vector3)
        Vector3 interactPos = transform.position + faceDirection;

        //������ꏊ��Ray���΂�
        Collider2D collider2D = Physics2D.OverlapCircle(interactPos, 0.1f, interactableLayer);
        if (collider2D)
        {
            collider2D.GetComponent<NPC>().Interact();
        }
    }

    //�R���[�`�����g���ď��X�ɖړI�n�ɋ߂Â���
    IEnumerator Move(Vector3 targetPos)
    {
        //�ړ����͓��͂��󂯕t�������Ȃ�
        isMoving = true;

        //targetPos�Ƃ̍�������Ȃ�J��Ԃ�
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //targetPos�ɋ߂Â���
            transform.position = Vector3.MoveTowards(
                transform.position, //���݂̏ꏊ
                targetPos,          //�ړI�n
                moveSpeed * Time.deltaTime
                );
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
        CheckForArea();
        CheckForEncounters();
    }

    //targetPos�Ɉړ��\���𒲂ׂ�֐�
    bool IsWalkable(Vector2 targetPos)
    {
        //targetPos�ɔ��a0.1f�̉~��Ray���΂��āA�Ԃ���Ȃ�����
        return Physics2D.OverlapCircle(targetPos, 0.1f,solidObjectsLayer | interactableLayer) == false;
    }

    //�����̏ꏊ����A�~��Ray���΂��āA�G���J�E���gLayer�ɓ���������A�����_���G���J�E���g����
    void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f, encountLayer))
        {
            //�����_���G���J�E���g
            if (UnityEngine.Random.Range(0,100) < 10)
            {
                //Random.Range(0,100):0�`90�܂ł̂ǂꂩ�̐������o��
                //10��菬����������0�`9�܂ł�10��:10%�̊m��
                //10�ȏ�̐�����10�`99�܂ł�90��
                Debug.Log("�����X�^�[�ɑ���");
            }

        }

    }
    //�����̏ꏊ����A�~��Ray���΂��āA�V�[���ړ�Layer�ɓ���������A�V�[����؂�ւ���
    void CheckForArea()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)input, 0.1f, TransitionAreaLayer);

        //�Ȃɂ��ƏՓ˂������������̃I�u�W�F�N�g�̖��O�����O�ɏo��
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

        //�g��������̐ݒ�;�o��������̃��x���ȏ�Ȃ�ASpells�ɒǉ�
        foreach (LearnableSpell spell in LearnableSpells)
        {
            if (pLevel >= leanablespell.Level)
            {
                //�������o����
                Spells.Add(new Spell(leanablespell.Base));
            }
                
        }

    }*/
}

//�o��������N���X:�ǂ̃��x���ŉ����o����̂�
[Serializable]
public class LearnableSpell
{
    //�q�G�����L�[�Őݒ肷��
    [SerializeField] SpellBase _base;
    [SerializeField] int level;

    public SpellBase Base { get => _base; }
    public int Level { get => level; }
}

