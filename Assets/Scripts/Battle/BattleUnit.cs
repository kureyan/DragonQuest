using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour //�키�����X�^�[���Z�b�g����
{
    [SerializeField] MonsterBase _base;
    [SerializeField] Text nameText;

    public Monster Monster { get; set; }

    //�����X�^�[�̉摜�Ɩ��O�𔽉f����
    public void SetMonsterData()
    {
        Monster = new Monster(_base);
        Image image = GetComponent<Image>(); 
        image.sprite = Monster.Base.MonsterSprite;
        nameText.text = Monster.Base.Name;
    }

}
