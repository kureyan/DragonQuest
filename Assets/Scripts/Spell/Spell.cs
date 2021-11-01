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
    public Spell(SpellBase _Base)
    {
        Base = _Base;
        MP = _Base.MP;
    }

}
