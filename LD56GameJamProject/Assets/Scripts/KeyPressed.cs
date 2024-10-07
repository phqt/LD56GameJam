using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    void Update()
    {
        // 检查玩家是否按下了R键
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 输出调试信息，确认按下了R键
            Debug.Log("R key was pressed, quitting the game...");

            // 退出游戏
            Application.Quit();

            // 在编辑器中，Application.Quit() 不会生效，可以输出调试信息来确认
#if UNITY_EDITOR
            Debug.Log("Application.Quit() does not work in the editor. To test quitting, build the project.");
#endif
        }
    }
}
