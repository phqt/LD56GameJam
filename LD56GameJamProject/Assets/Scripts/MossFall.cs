using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MossFall : MonoBehaviour
{
    private bool isHealed = false;
    public GameObject thePlayer;
    public float healAmount = 50f;

    public PlayerHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isHealed)
        {
            Debug.Log("player on moss");
            thePlayer.GetComponent<PlayerHealth>().Heal(healAmount);
            isHealed = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log("player on moss");
    //        thePlayer.GetComponent<PlayerMovement>().resetVelocity();
    //    }

    //}
}