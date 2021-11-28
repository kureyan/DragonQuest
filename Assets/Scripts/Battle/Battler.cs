using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    //HPを持っている
    public new string name;
    public int hp;

    //実行するコマンド
    public CommandSO selectCommandSO;
    public Battler target;

    //持ってるコマンド
    public CommandSO[] commands;

}
