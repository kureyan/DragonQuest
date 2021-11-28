using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealCommandSO : CommandSO
{
    [SerializeField] int healPoint;

    //CommandSO��Execute�͎��s�����ɏ㏑�����Ď��s����
    public override void Execute(Battler user, Battler target)
    {
        target.hp += healPoint;
        Debug.Log($"{target.name}��{healPoint}��:�c��HP{target.hp}");
    }
}
