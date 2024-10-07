using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnterLeaf : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject endLeaf;
    public GameObject middleLeaf;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3[] pathPoints = new Vector3[3];
        pathPoints[0] = this.transform.position;  
        pathPoints[1] = middleLeaf.transform.position;  
        pathPoints[2] = endLeaf.transform.position;

        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        thePlayer.transform.DOPath(pathPoints, 2f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
         {
             thePlayer.GetComponent<PlayerMovement>().enabled = true;
         });
    }
}
