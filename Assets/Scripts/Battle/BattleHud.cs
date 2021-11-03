using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text hpText;
    [SerializeField] Text mpText;
    [SerializeField] Text levelText;


    public void SetPlayerData(Player player)
    {
        //nameText.text = player.PName;
        hpText.text = "HP    " + player.HP;
        mpText.text = "MP    " + player.MP;
        levelText.text = "LV    "+ player.Level;
    }
    public void SetMonsterData(Monster monster)
    {
        //nameText.text = monster.Base.Name;
        //hpText.text =??;
        //mpText.text =??;
    }
}
