using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBattleMenuCommand : MonoBehaviour
{
    //SelectableText���I�����ꂽ��
    //�J�[�\���̈ړ�������
    [SerializeField] Transform arrow = default;

    //SelectableText���I�����ꂽ��
    //SelectableText��MoveArrowTo�̊֐��̓o�^���s��
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();

    private void Start()
    {
        SetMoveArriwFunction();
    }

    void SetMoveArriwFunction()
    {
        foreach(SelectableText selectableText in selectableTexts)
        {
            selectableText.OnSelectAction = MoveArrowTo;
        }
    }

    //�J�[�\���̈ړ�������:�e��ύX����
    public void MoveArrowTo(Transform parent)
    {
        Debug.Log("�J�[�\���ړ�");
        arrow.SetParent(parent);
    }
}
