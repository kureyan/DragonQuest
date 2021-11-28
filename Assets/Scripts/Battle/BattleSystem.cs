using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleDialogBox dialogBox;

    [SerializeField] Battler player;
    [SerializeField] Battler enemy;


    int currentCommand; // 0:�������� 1:������� 2:�ɂ��� 3:�ǂ���
    enum Phase
    {
        StartPhase,
        ChooseCommandPhase, //�R�}���h�I��
        ExcutePhase,        //���s
        Result,
        End,
    }

    Phase phase;

    private void Start()
    {
        StartCoroutine(SetupBattle());
        phase = Phase.StartPhase;
        StartCoroutine(Battle());
    }

    IEnumerator SetupBattle()
    {
        //�v���C���[�f�[�^�̕\��
        playerHud.SetPlayerData();
        //�����X�^�[���Ɖ摜�\��
        enemyUnit.SetMonsterData();

        dialogBox.EnableDialogText(true);
        //$������ƃJ�b�R�̒��ɕϐ����g����
        dialogBox.SetDialog($"{enemyUnit.Monster.Base.Name}�� �����ꂽ�I");
        //�^�C�v�`���ŕ�����\������ꍇ
        //yield return dialogBox.TypeDialog($"{enemyUnit.Monster.Base.Name}�� �����ꂽ�I");
        yield return new WaitForSeconds(1);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableCommandSelector(true);
    }

    IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            yield return null;
            Debug.Log(phase);
            switch (phase)
            {
                case Phase.StartPhase:
                    phase = Phase.ChooseCommandPhase;
                    break;
                case Phase.ChooseCommandPhase:
                    //�Z�I���������玟�̃t�F�[�Y�ɂ���
                    //new WaitUntil(() => ������true�ɂȂ�܂őҋ@����
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                    phase = Phase.ExcutePhase;
                    break;
                case Phase.ExcutePhase:
                    player.Attack(enemy);
                    enemy.Attack(player);
                    //�ǂ��炩�����S������
                    if(player.hp<=0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                    }
                    else
                    {
                        phase = Phase.ChooseCommandPhase;
                    }
                    break;
                case Phase.Result:
                    phase = Phase.End;
                    break;
                case Phase.End:
                    break;
            }
        }
    }



    private void Update()
    {

        // �R�}���h�I��
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentCommand < 3)
            {
                currentCommand++;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentCommand > 0)
            {
                currentCommand--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableSpellSelector(true);
        }
    }

}
