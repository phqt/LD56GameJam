using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 导入SceneManager的命名空间

public class KeyPressed : MonoBehaviour
{

    void Update()
    {
        // 检查玩家是否按下了R键
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 重新加载当前场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}