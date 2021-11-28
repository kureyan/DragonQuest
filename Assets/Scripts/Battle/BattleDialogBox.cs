using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    //����:dialog��Text���擾���āA�ύX����
    [SerializeField] Text dialogText;

    [SerializeField] GameObject commandSelector;
    [SerializeField] GameObject spellSelector;
    [SerializeField] GameObject spellDetails;
    [SerializeField] GameObject massageBox;


    [SerializeField] List<Text> commandTexts;
    [SerializeField] List<Text> SpellTexts;


    [SerializeField] Text mpText;
    [SerializeField] Text spellDescription;

    //�^�C�v�`���ŕ�����\������ꍇ
    //[SerializeField] int letterPerSecond //1����������̕\������

    //Text��ύX���邽�߂̊֐�
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //�^�C�v�`���ŕ�����\������
    /*public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach(char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond); //1f/30=>1�b��30����
        }
    }*/

    //UI�̕\��/��\��������

    //commandSelector�̕\���Ǘ�
    public void EnableDialogText(bool enabled)
    {
        massageBox.SetActive(enabled);
    }

    //commandSelector�̕\���Ǘ�
    public void EnableCommandSelector(bool enabled)
    {
        commandSelector.SetActive(enabled);
    }

    //spellSelector�̕\���Ǘ�
    public void EnableSpellSelector(bool enabled)
    {
        spellSelector.SetActive(enabled);
        spellDetails.SetActive(enabled);

    }

    public void UpdateCommandSelection(int selectCommand)
    {

    }

}
