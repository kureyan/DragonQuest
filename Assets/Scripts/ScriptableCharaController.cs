using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableCharaController : MonoBehaviour
{

	public MonsterBase enemyData;

	void Start()
	{
		ShowScriptableObjectData();
	}

	void Update()
	{

	}

	void ShowScriptableObjectData()
	{
		// 参照しているEnemyDataの中身をコンソールに表示する
		Debug.Log("私の名前は" + enemyData.Name +
					", 最大HPは" + enemyData.MaxHP +
					", 攻撃力は" + enemyData.Attack +
					", 防御力は" + enemyData.Defence +
					", 経験値は" + enemyData.Exp +
					", ゴールドは" + enemyData.Gold + "です。");
	}
}