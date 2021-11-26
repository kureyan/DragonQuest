using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleDialogBox dialogBox;

    private void Start()
    {
        StartCoroutine(SetupBattle());
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableSpellSelector(true);
        }
    }

}
