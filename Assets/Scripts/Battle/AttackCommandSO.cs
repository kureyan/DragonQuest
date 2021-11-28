using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int AttackPoint;

    //CommandSOのExecuteは実行せずに上書きして実行する
    public override void Execute(Battler user, Battler target)
    {
        target.hp -= AttackPoint;
        Debug.Log($"{target.name}に{AttackPoint}のダメージ:残りHP{target.hp}");
    }
}
