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


    int currentCommand; // 0:こうげき 1:じゅもん 2:にげる 3:どうぐ
    enum Phase
    {
        StartPhase,
        ChooseCommandPhase, //コマンド選択
        ExcutePhase,        //実行
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
                    //技選択をしたら次のフェーズにいく
                    //new WaitUntil(() => ここがtrueになるまで待機する
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                    phase = Phase.ExcutePhase;
                    break;
                case Phase.ExcutePhase:
                    player.Attack(enemy);
                    enemy.Attack(player);
                    //どちらかが死亡したら
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

        // コマンド選択
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
