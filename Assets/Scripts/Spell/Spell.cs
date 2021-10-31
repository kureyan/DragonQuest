using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    //呪文のマスターデータをもつ
    //使いやすいようにするためにMPももつ
    //他のファイルが参照するのでpublicにしておく
    public SpellBase Base { get; set; }
    public int MP { get; set; }

    //初期設定
    public Spell(SpellBase pBase)
    {
        Base = pBase;
        MP = pBase.MP;
    }

}
