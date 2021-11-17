using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour //戦うモンスターをセットする
{
    [SerializeField] MonsterBase _base;
    [SerializeField] Text nameText;

    public Monster Monster { get; set; }

    //モンスターの画像と名前を反映する
    public void SetMonsterData()
    {
        Monster = new Monster(_base);
        Image image = GetComponent<Image>(); 
        image.sprite = Monster.Base.MonsterSprite;
        nameText.text = Monster.Base.Name;
    }

}
