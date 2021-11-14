using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    //public string areaToLoad;
    public MapData areaToLoad;

    Player player;
    //public static Vector2 zahyou = new Vector2(-18.5f, 18.8f);

    public static List<Vector2> zahyou = new List<Vector2>();

    //public MapData map;


    public List<Vector2> LoadArea(string name)
    {
        //ワールドマップから移動する場合はシーン移動の前に位置を保存したい
        //あるいは町の座標をマスターデータにして町から出たときはその座標からスタート
        //こっちができればルーラにも応用できる

        zahyou = areaToLoad.Zahyou;
        //Debug.Log("座標"+map.Zahyou);
        //player.transform.position = map.Zahyou;






        //シーン移動
        SceneManager.LoadScene(areaToLoad.Name);
        return zahyou;
        
    }
}