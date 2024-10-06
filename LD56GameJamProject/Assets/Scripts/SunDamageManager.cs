using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunDamageManager : MonoBehaviour
{
    public bool inSun;
    public bool stopDamage;

    public GameObject thePlayer;
    public float damageAmount = 10f;

    public float scaleReductionFactor = 0.8f;

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
        yield return new WaitForSeconds(1);
        thePlayer.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        //thePlayer.transform.DOScale(0.8f, 1f).SetEase(Ease.OutBounce);
        Vector3 newScale = thePlayer.transform.localScale * scaleReductionFactor;
        thePlayer.transform.DOScale(newScale, 1f).SetEase(Ease.OutBounce);
        stopDamage = false;
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
