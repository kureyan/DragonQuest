using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    //�����̃}�X�^�[�f�[�^������
    //�g���₷���悤�ɂ��邽�߂�MP������
    //���̃t�@�C�����Q�Ƃ���̂�public�ɂ��Ă���
    public SpellBase Base { get; set; }
    public int MP { get; set; }

    //�����ݒ�
    public Spell(SpellBase _Base)
    {
        Base = _Base;
        MP = _Base.MP;
    }

}
