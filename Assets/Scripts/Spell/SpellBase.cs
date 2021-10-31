using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellBase : ScriptableObject
{
    //�����̃}�X�^�[�f�[�^

    //ID,���O,�ڍ�,MP
    //���ʂ͊֐��ō�肽��

    [SerializeField] string spellid;
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int mp;

    //���̃t�@�C��(Spell.cs)����Q�Ƃ��邽�߂Ƀv���p�e�B
    public string Spellid { get => spellid; }
    public string Name { get => name; }
    public string Description { get => description; }
    public int MP { get => mp; }

   

}
