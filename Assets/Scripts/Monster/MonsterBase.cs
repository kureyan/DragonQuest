using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����X�^�[�̃}�X�^�[�f�[�^�F�O������ύX���Ȃ�(�C���X�y�N�^�[�����ύX�\)
[CreateAssetMenu]
public class MonsterBase : ScriptableObject
{
    //���O,����,�^�C�v,�X�e�[�^�X
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;

    //�摜
    [SerializeField] Sprite monsterSprite;

    //�X�e�[�^�X:hp,mp,at,df,sp,exp,g
    [SerializeField] int maxHP;
    [SerializeField] int maxMP;
    [SerializeField] int attack;
    [SerializeField] int defence;
    [SerializeField] int speed;
    [SerializeField] int exp;
    [SerializeField] int gold;

    //���t�@�C������attack�̒l�̎擾�͂ł��邪�ύX�͂ł��Ȃ�
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
