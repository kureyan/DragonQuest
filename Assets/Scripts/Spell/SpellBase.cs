using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellBase : ScriptableObject
{
    //呪文のマスターデータ

    //ID,名前,詳細,MP
    //効果は関数で作りたい

    [SerializeField] string spellid;
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int mp;

    //他のファイル(Spell.cs)から参照するためにプロパティ
    public string Spellid { get => spellid; }
    public string Name { get => name; }
    public string Description { get => description; }
    public int MP { get => mp; }

   

}
