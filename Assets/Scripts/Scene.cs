using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    //public string areaToLoad;
    public MapData map;
    public int element;//MapData���W�̗v�f�ԍ�
    public static int num;

    Player player;
    //public static Vector2 zahyou = new Vector2(-18.5f, 18.8f);

    public static List<Vector2> zahyou = new List<Vector2>();

    //public MapData map;


    public (List<Vector2>,int) LoadArea(string name)
    {
        //���[���h�}�b�v����ړ�����ꍇ�̓V�[���ړ��̑O�Ɉʒu��ۑ�������
        //���邢�͒��̍��W���}�X�^�[�f�[�^�ɂ��Ē�����o���Ƃ��͂��̍��W����X�^�[�g
        //���������ł���΃��[���ɂ����p�ł���

        zahyou = map.Zahyou;

        num = element;

        //�V�[���ړ�
        SceneManager.LoadScene(map.Name);
        return (zahyou,num);
        
    }

    public void GameStart()
    {
        zahyou = map.Zahyou;
        SceneManager.LoadScene("Castle1-2");
    }
}