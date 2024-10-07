using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float healthAmount = 50f;
    public GameObject thePlayer;
    private SpriteRenderer spritePlayer;

    private Vector3 currentScale;

    public float waterPickedUp;

    public void TakeDamage(float damageAmount)
    {
        healthAmount -= damageAmount;
        if (healthAmount <= 0f)
        {
            Die();
        }
    }

    public void Heal (float healAmount)
    {
        healthAmount += healAmount;
        if (healthAmount > maxHealth)
        {
            healAmount = maxHealth;
        }
    }

    private void Update()
    {
        currentScale = thePlayer.transform.localScale;

        if (currentScale.y >= 25.6f)
        {
            currentScale = new Vector3(currentScale.x, 25.6f, 25.6f);
            thePlayer.transform.localScale = currentScale;
        }
    }

 


    public void resetHealth()
    {
        healthAmount = 50f;
    }

    public void Die()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        spritePlayer = gameObject.GetComponent<SpriteRenderer>();
        spritePlayer.DOFade(0, 1f).SetEase(Ease.InOutSine).WaitForCompletion();
        StartCoroutine(waitToKill());
    }

    IEnumerator waitToKill()
    {
        yield return new WaitForSeconds(1);
        thePlayer.SetActive(false);
    }
}
