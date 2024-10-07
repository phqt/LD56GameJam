using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneSwitcher : MonoBehaviour
{
    // 指定要切换到的场景名称
    public string targetSceneName = "TestingScene";

    void Start()
    {
        // 启动协程，在场景加载后等待1秒然后切换场景
        StartCoroutine(SwitchSceneAfterDelay(1f));  // 1秒延迟
    }

    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        // 等待指定的秒数
        yield return new WaitForSeconds(delay);

        // 切换到指定的场景
        SceneManager.LoadScene(targetSceneName);
    }
}
