using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    //ベースとなるデータ
    MonsterBase _base;

    //使える呪文
    public List<Spell> Spells { get; set; }

    //コンストラクター:生成時の初期設定
    public Monster(MonsterBase mBase)
    {
        _base = mBase;

        //使える呪文の設定
    }
}
