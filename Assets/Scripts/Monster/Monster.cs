using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    //�x�[�X�ƂȂ�f�[�^
    public MonsterBase Base { get; set; }

    //�g�������
    public List<Spell> Spells { get; set; }

    //�R���X�g���N�^�[:�������̏����ݒ�
    public Monster(MonsterBase mBase)
    {
        Base = mBase;

        Spells = new List<Spell>();

        //�g��������̐ݒ�
    }
}
