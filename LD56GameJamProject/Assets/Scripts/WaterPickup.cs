using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterPickup : MonoBehaviour
{
    public GameObject thePlayer;
    private SpriteRenderer spriteR;
    private bool isPickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPickedUp)
        {
            Debug.Log("player collided");
            isPickedUp = true;
            thePlayer.transform.DOScale(1.6f, 2f).SetEase(Ease.OutBounce);
            spriteR = gameObject.GetComponent<SpriteRenderer>();
            spriteR.DOFade(0, 1f).SetEase(Ease.InOutSine).WaitForCompletion();
            StartCoroutine(destroyDelay());
        }

        IEnumerator destroyDelay()
        {
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
        }
    }
}
