using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealer : MonoBehaviour
{
    public GameObject thePlayer;
    public float healAmount = 50f;

    public PlayerHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player on mushroom moss");
            thePlayer.GetComponent<PlayerHealth>().Heal(healAmount);

        }
    }
}
