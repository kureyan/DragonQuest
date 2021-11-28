using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    //役割:dialogのTextを取得して、変更する
    [SerializeField] Text dialogText;

    [SerializeField] GameObject commandSelector;
    [SerializeField] GameObject spellSelector;
    [SerializeField] GameObject spellDetails;
    [SerializeField] GameObject massageBox;


    [SerializeField] List<Text> commandTexts;
    [SerializeField] List<Text> SpellTexts;


    [SerializeField] Text mpText;
    [SerializeField] Text spellDescription;

    //タイプ形式で文字を表示する場合
    //[SerializeField] int letterPerSecond //1文字あたりの表示時間

    //Textを変更するための関数
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //タイプ形式で文字を表示する
    /*public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach(char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond); //1f/30=>1秒で30文字
        }
    }*/

    //UIの表示/非表示をする

    //commandSelectorの表示管理
    public void EnableDialogText(bool enabled)
    {
        massageBox.SetActive(enabled);
    }

    //commandSelectorの表示管理
    public void EnableCommandSelector(bool enabled)
    {
        commandSelector.SetActive(enabled);
    }

    //spellSelectorの表示管理
    public void EnableSpellSelector(bool enabled)
    {
        spellSelector.SetActive(enabled);
        spellDetails.SetActive(enabled);

    }

    public void UpdateCommandSelection(int selectCommand)
    {

    }

}
