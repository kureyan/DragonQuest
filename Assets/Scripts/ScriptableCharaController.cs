using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableCharaController : MonoBehaviour
{

	public MonsterBase enemyData;
	GameObject PlayerObj;
	Player player;

	void Start()
	{
		ShowScriptableObjectData();
	}

	void Update()
	{

	}

	void ShowScriptableObjectData()
	{
		// �Q�Ƃ��Ă���EnemyData�̒��g���R���\�[���ɕ\������
		Debug.Log("���̖��O��" + enemyData.Name +
					", �ő�HP��" + enemyData.MaxHP +
					", �U���͂�" + enemyData.Attack +
					", �h��͂�" + enemyData.Defence +
					", �o���l��" + enemyData.Exp +
					", �S�[���h��" + enemyData.Gold + "�ł��B");
		PlayerObj = GameObject.Find("Player");
		player = PlayerObj.GetComponent<Player>();
		Debug.Log("�킽���̖��O��"+player.Name);
	}
}