using UnityEngine;

public class Singleton : MonoBehaviour
{
    //�C���X�^���X�����݂��邩�H

    static bool existsInstance = false;

    void Awake()
    {
        if (existsInstance)
        {
            Destroy(gameObject);
            return;
        }

        existsInstance = true;

        DontDestroyOnLoad(gameObject);
    }

}