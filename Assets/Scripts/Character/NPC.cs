using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //干渉された時に実行する関数
    public void Interact()
    {
        Debug.Log("NPCと会話");
    }
}
