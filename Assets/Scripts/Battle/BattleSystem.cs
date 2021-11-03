using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleUnit enemyUnit;
    Player player;

    private void Start()
    {

        //playerHud.SetPlayerData(player);
        //enemyHud.SetMonsterData(enemyUnit.Monster);
        enemyUnit.Setup();
    }
}
