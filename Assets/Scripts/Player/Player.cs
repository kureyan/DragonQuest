using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player��1�}�X�ړ�

    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;

    Animator animator;

    //�ǔ����Layer
    [SerializeField] LayerMask solidObjectsLayer;
    //�G���J�E���g�����Layer
    [SerializeField] LayerMask encountLayer;

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
        CheckForEncounters();
    }

    //targetPos�Ɉړ��\���𒲂ׂ�֐�
    bool IsWalkable(Vector2 targetPos)
    {
        //targetPos�ɔ��a0.1f�̉~��Ray���΂��āA�Ԃ���Ȃ�����
        return Physics2D.OverlapCircle(targetPos, 0.1f,solidObjectsLayer) == false;
    }

    //�����̏ꏊ����A�~��Ray���΂��āA�G���J�E���gLayer�ɓ���������A�����_���G���J�E���g����
    void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f, encountLayer))
        {
            //�����_���G���J�E���g
            if (Random.Range(0,100) < 10)
            {
                //Random.Range(0,100):0�`90�܂ł̂ǂꂩ�̐������o��
                //10��菬����������0�`9�܂ł�10��:10%�̊m��
                //10�ȏ�̐�����10�`99�܂ł�90��
                Debug.Log("�����X�^�[�ɑ���");
            }

        }

    }

}