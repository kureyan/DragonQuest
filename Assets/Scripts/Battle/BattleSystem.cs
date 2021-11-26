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
        //プレイヤーデータの表示
        playerHud.SetPlayerData();
        //モンスター名と画像表示
        enemyUnit.SetMonsterData();

        dialogBox.EnableDialogText(true);
        //$をつけるとカッコの中に変数が使える
        dialogBox.SetDialog($"{enemyUnit.Monster.Base.Name}が あらわれた！");
        //タイプ形式で文字を表示する場合
        //yield return dialogBox.TypeDialog($"{enemyUnit.Monster.Base.Name}が あらわれた！");
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
