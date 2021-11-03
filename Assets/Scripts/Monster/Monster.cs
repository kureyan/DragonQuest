using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    //ベースとなるデータ
    public MonsterBase Base { get; set; }

    //使える呪文
    public List<Spell> Spells { get; set; }

    //コンストラクター:生成時の初期設定
    public Monster(MonsterBase mBase)
    {
        Base = mBase;

        Spells = new List<Spell>();

        //使える呪文の設定
    }
}
