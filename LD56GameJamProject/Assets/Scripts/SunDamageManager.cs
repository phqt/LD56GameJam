using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunDamageManager : MonoBehaviour
{
    public bool inSun;
    public bool stopDamage;

    public GameObject thePlayer;
    public float damageAmount = 3f;

    public float scaleReductionFactor = 0.8f;

    public float sunDamageDelay = 0.5f;

    void Update()
    {
        if (inSun == true)
        {
            if (stopDamage == false)
            {
                stopDamage = true;
                StartCoroutine(sunDamage());
            }
        }
    }

    IEnumerator sunDamage()
    {
        yield return new WaitForSeconds(sunDamageDelay);
        AudioManager.instance.PlaySound(AudioManager.SoundEffect.Sunburn);
        thePlayer.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        Vector3 newScale = thePlayer.transform.localScale * scaleReductionFactor;
        thePlayer.transform.DOScale(newScale, 0.3f).SetEase(Ease.InOutSine);
        thePlayer.GetComponent<Animator>().SetBool("SizeI", false);
        thePlayer.GetComponent<Animator>().SetBool("SizeD", true);
        thePlayer.GetComponent<Animator>().SetBool("isWalk", false);
        thePlayer.GetComponent<Animator>().SetBool("isJump", false);
        stopDamage = false;
        Invoke("ResetSizeI", 1.5f);
    }

    private void ResetSizeI()
    {
        thePlayer.GetComponent<Animator>().SetBool("SizeD", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sun")
        {
            inSun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sun")
        {
            inSun = false;
        }
    }
}
