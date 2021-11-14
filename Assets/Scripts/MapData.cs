using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapData : ScriptableObject
{
    //�}�b�v�̍��W�f�[�^

    //���O,�ڍ�,���W

    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] List<Vector2> zahyou;

    public string Name { get => name; }
    public string Description { get => description; }
    public List<Vector2> Zahyou { get => zahyou; }



}
