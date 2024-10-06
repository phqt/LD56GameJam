using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterOnSpawn : MonoBehaviour
{
    public float waterTargetYLocation;
    public float waterFallTime;
    private SpriteRenderer spriteR;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.DOFade(0, 1f).SetEase(Ease.InOutSine);
        transform.DOMoveY(waterTargetYLocation, waterFallTime).SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                this.GetComponent<WaterPickup>().enabled = true;
            });

    }
}
