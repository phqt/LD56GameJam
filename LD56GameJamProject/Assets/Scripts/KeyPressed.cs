using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // ����SceneManager�������ռ�

public class KeyPressed : MonoBehaviour
{

    void Update()
    {
        // �������Ƿ�����R��
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ���¼��ص�ǰ����
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}