using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    public string areaToLoad;

    public void LoadArea()
    {
        //���[���h�}�b�v����ړ�����ꍇ�̓V�[���ړ��̑O�Ɉʒu��ۑ�������
        //���邢�͒��̍��W���}�X�^�[�f�[�^�ɂ��Ē�����o���Ƃ��͂��̍��W����X�^�[�g
        //���������ł���΃��[���ɂ����p�ł���

        //�V�[���ړ�
        SceneManager.LoadScene(areaToLoad);

    }
}