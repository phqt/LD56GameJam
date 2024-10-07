using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    void Update()
    {
        // �������Ƿ�����R��
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ���������Ϣ��ȷ�ϰ�����R��
            Debug.Log("R key was pressed, quitting the game...");

            // �˳���Ϸ
            Application.Quit();

            // �ڱ༭���У�Application.Quit() ������Ч���������������Ϣ��ȷ��
#if UNITY_EDITOR
            Debug.Log("Application.Quit() does not work in the editor. To test quitting, build the project.");
#endif
        }
    }
}
