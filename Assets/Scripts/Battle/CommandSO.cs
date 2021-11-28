using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CommandSO : ScriptableObject
{
    public new string name;

    //���s
    public virtual void Execute(Battler user, Battler target)
    {
        target.hp -= 3;
        Debug.Log($"{user.name}�̍U��:{target.name}��{3}�̃_���[�W:�c��HP{target.hp}");
    }
}
