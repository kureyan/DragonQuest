using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    //�x�[�X�ƂȂ�f�[�^
    MonsterBase _base;

    //�g�������
    public List<Spell> Spells { get; set; }

    //�R���X�g���N�^�[:�������̏����ݒ�
    public Monster(MonsterBase mBase)
    {
        _base = mBase;

        //�g��������̐ݒ�
    }
}
