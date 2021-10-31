using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Z : ScriptableObject
{
    //呪文のマスターデータ

    //名前,詳細,座標

    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] Vector2 zahyou;

    public string Name { get => name; }
    public string Description { get => description; }
    public Vector2 Zahyou { get => zahyou; }



}
