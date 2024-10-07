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

    // ʹ��static��������ֹ��������ʱ������
    private static bool hasTriggered = false;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����Ѿ���������ֱ�ӷ��أ����ٴ���
        if (hasTriggered)
            return;

        if (collision.CompareTag("Player"))
        {
            hasTriggered = true;  // ���Ϊ�Ѿ�������

            // ������ҿ���
            if (playerMovement != null)
            {
                playerMovement.enabled = false;  // ֹͣ��ҿ���
            }

            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;  // ֹͣ����˶�
                playerRb.isKinematic = true;       // ��ֹ�����˶�
            }

            // ����Э�̿�ʼ�𽥱��
            StartCoroutine(FadeToWhite());
        }
    }

    private IEnumerator FadeToWhite()
    {
        float elapsedTime = 0f;
        Color currentColor = fadeImage.color;

        // �𽥽�alpha��0�䵽1
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        // ��ȫ��׺�ִ����Ϸ�����߼�
        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // ���¼��ص�ǰ����
    }
}
