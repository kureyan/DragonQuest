using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IInteractableを継承しているクラスは、必ずInteract関数を持っている(抽象化)
public interface IInteractable
{
    //関数を宣言する
    public void Interact();
}
