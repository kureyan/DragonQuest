using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    //�֐��o�^�p�̕ϐ�
    public UnityAction<Transform> OnSelectAction = null;

    //�I����ԂɂȂ������ɏ���Ɏ��s�����֐�
    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}���I�����ꂽ");
        //�o�^�֐������s����
        OnSelectAction.Invoke(transform);
    }

    //�񂦂����������I����ԂɂȂ������ɏ���Ɏ��s�����֐�
        public override void OnDeselect(BaseEventData eventData)
    {
        //base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name}�̑I�����O���ꂽ");
    }
}
