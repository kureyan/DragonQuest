using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    //HP�������Ă���
    public new string name;
    public int hp;

    //�U�����ł���
    public void Attack(Battler target)
    {
        target.hp -= 3;
        Debug.Log($"{name}�̍U��:{target.name}��{3}�̃_���[�W:�c��HP{target.hp}");
    }
}
