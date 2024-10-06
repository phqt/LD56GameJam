using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterPickup : MonoBehaviour
{
    public GameObject thePlayer;
    private SpriteRenderer spriteR;
    private bool canPickUp = true;
    public float scaleAdding = 1.6f;


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
            if (thePlayer.transform.localScale.x >= -25f && thePlayer.transform.localScale.x <= 25f && thePlayer.transform.localScale.x <= 25f)
            {
                thePlayer.GetComponent<Animator>().SetBool("SizeI", true);
                thePlayer.GetComponent<Animator>().SetBool("SizeD", false);
                thePlayer.GetComponent<Animator>().SetBool("isWalk", false);
                thePlayer.GetComponent<Animator>().SetBool("isJump", false);

                //thePlayer.GetComponent<PlayerHealth>().addWater(1);
                canPickUp = false;

                Rigidbody2D playerRb = thePlayer.GetComponent<Rigidbody2D>();
                playerRb.velocity = Vector2.zero;

                thePlayer.GetComponent<PlayerMovement>().enabled = false;

                Vector3 newScale = thePlayer.transform.localScale * scaleAdding;

                thePlayer.transform.DOScale(newScale, 2f).SetEase(Ease.InOutSine).OnComplete(() => 
                    {
                    thePlayer.GetComponent<PlayerMovement>().enabled = true;
                    Invoke("ResetSizeI", 1f);
                    });

                //thePlayer.GetComponent<PlayerMovement>().enabled = true;
                spriteR = gameObject.GetComponent<SpriteRenderer>();
                spriteR.DOFade(0, 0.01f).SetEase(Ease.InOutSine).OnComplete(() => {
                    Destroy(gameObject);
                });
            }
           
        }

    }

    private void ResetSizeI()
    {
        thePlayer.GetComponent<Animator>().SetBool("SizeI", false);
    }
}
