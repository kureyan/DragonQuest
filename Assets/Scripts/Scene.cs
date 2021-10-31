using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    public string areaToLoad;

    public void LoadArea()
    {
        //ワールドマップから移動する場合はシーン移動の前に位置を保存したい
        //あるいは町の座標をマスターデータにして町から出たときはその座標からスタート
        //こっちができればルーラにも応用できる

        //シーン移動
        SceneManager.LoadScene(areaToLoad);

    }
}