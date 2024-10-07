using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerGameEnd : MonoBehaviour
{
    public GameObject player;
    public Image fadeImage;
    public float fadeDuration = 2f;

    private Rigidbody2D playerRb;
    private PlayerMovement playerMovement;

    // 使用static变量来防止场景重载时被重置
    private static bool hasTriggered = false;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果已经触发过，直接返回，不再触发
        if (hasTriggered)
            return;

        if (collision.CompareTag("Player"))
        {
            hasTriggered = true;  // 标记为已经触发过

            // 禁用玩家控制
            if (playerMovement != null)
            {
                playerMovement.enabled = false;  // 停止玩家控制
            }

            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;  // 停止玩家运动
                playerRb.isKinematic = true;       // 禁止物理运动
            }

            // 启动协程开始逐渐变白
            StartCoroutine(FadeToWhite());
        }
    }

    private IEnumerator FadeToWhite()
    {
        float elapsedTime = 0f;
        Color currentColor = fadeImage.color;

        // 逐渐将alpha从0变到1
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        // 完全变白后，执行游戏结束逻辑
        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // 重新加载当前场景
    }
}
