using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneSwitcher : MonoBehaviour
{
    // ָ��Ҫ�л����ĳ�������
    public string targetSceneName = "TestingScene";

    void Start()
    {
        // ����Э�̣��ڳ������غ�ȴ�1��Ȼ���л�����
        StartCoroutine(SwitchSceneAfterDelay(1f));  // 1���ӳ�
    }

    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        // �ȴ�ָ��������
        yield return new WaitForSeconds(delay);

        // �л���ָ���ĳ���
        SceneManager.LoadScene(targetSceneName);
    }
}
