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

    GameObject PlayerObj;
    Player player;

    public void SetPlayerData()
    {
        PlayerObj = GameObject.Find("Player");
        player = PlayerObj.GetComponent<Player>();
        nameText.text = player.Name;
        hpText.text = "HP    " + player.HP;
        mpText.text = "MP    " + player.MP;
        levelText.text = "LV    "+ player.Level;
    }
}
