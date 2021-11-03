using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//モンスターのマスターデータ：外部から変更しない(インスペクターだけ変更可能)
[CreateAssetMenu]
public class MonsterBase : ScriptableObject
{
    //名前,説明,タイプ,ステータス
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;

    //画像
    [SerializeField] Sprite monsterSprite;

    //ステータス:hp,mp,at,df,sp,exp,g
    [SerializeField] int maxHP;
    [SerializeField] int maxMP;
    [SerializeField] int attack;
    [SerializeField] int defence;
    [SerializeField] int speed;
    [SerializeField] int exp;
    [SerializeField] int gold;

    //他ファイルからattackの値の取得はできるが変更はできない
    public int MaxHP { get => maxHP; }
    public int MaxMP { get => maxMP; }
    public int Attack { get => attack; }
    public int Defence { get => defence; }
    public int Speed { get => speed; }
    public int Exp { get => exp; }
    public int Gold { get => gold; }
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite MonsterSprite { get => monsterSprite; }
}
