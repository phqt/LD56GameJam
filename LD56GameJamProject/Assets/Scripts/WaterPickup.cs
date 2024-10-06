using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterPickup : MonoBehaviour
{
    public GameObject thePlayer;
    private SpriteRenderer spriteR;
    private bool canPickUp = true;

    public float waterLifetimeDuration = 7f;

    private void Start()
    {
        StartCoroutine(waterLifetime());
    }

    IEnumerator waterLifetime ()
    {
        yield return new WaitForSeconds(waterLifetimeDuration);
        canPickUp = false;
        transform.DOScaleX(2, 2).SetEase(Ease.InOutSine);
        transform.DOScaleY(0, 2).SetEase(Ease.InOutSine).OnComplete(() => {
            Destroy(gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canPickUp)
        {
            Debug.Log("player collided");
            if (thePlayer.GetComponent<PlayerHealth>().waterPickedUp <= 2f)
            {
                thePlayer.GetComponent<PlayerHealth>().addWater(1);
                canPickUp = false;
                thePlayer.GetComponent<PlayerMovement>().enabled = false;
                thePlayer.transform.DOScale(1.6f, 2f).SetEase(Ease.InOutSine).OnComplete(() => {
                    thePlayer.GetComponent<PlayerMovement>().enabled = true;
                });
                //thePlayer.GetComponent<PlayerMovement>().enabled = true;
                spriteR = gameObject.GetComponent<SpriteRenderer>();
                spriteR.DOFade(0, 1f).SetEase(Ease.InOutSine).OnComplete(() => {
                    Destroy(gameObject);
                });
            }
           
        }

    }
}
