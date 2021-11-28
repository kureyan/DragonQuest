using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int AttackPoint;

    //CommandSO��Execute�͎��s�����ɏ㏑�����Ď��s����
    public override void Execute(Battler user, Battler target)
    {
        target.hp -= AttackPoint;
        Debug.Log($"{target.name}��{AttackPoint}�̃_���[�W:�c��HP{target.hp}");
    }
}
