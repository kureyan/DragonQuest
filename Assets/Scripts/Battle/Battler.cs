using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    //HP�������Ă���
    public new string name;
    public int hp;

    //���s����R�}���h
    public CommandSO selectCommandSO;
    public Battler target;

    //�����Ă�R�}���h
    public CommandSO[] commands;

}
