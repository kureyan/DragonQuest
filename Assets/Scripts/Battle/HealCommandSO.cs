using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealCommandSO : CommandSO
{
    [SerializeField] int healPoint;

    //CommandSO‚ÌExecute‚ÍÀs‚¹‚¸‚Éã‘‚«‚µ‚ÄÀs‚·‚é
    public override void Execute(Battler user, Battler target)
    {
        target.hp += healPoint;
        Debug.Log($"{target.name}‚ğ{healPoint}‰ñ•œ:c‚èHP{target.hp}");
    }
}
