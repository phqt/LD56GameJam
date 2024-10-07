using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnterLeaf : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject endLeaf;
    public GameObject middleLeaf;

    public GameObject leaf;
    public Vector3 rotationAxis;  
    public float rotationAngle;   
    public float rotationDuration = 1f;

    private bool hasTriggered = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (hasTriggered) return;

        hasTriggered = true;

        if (leaf != null)
        {
            // 旋转叶子对象
            leaf.transform.DORotate(rotationAxis * rotationAngle, rotationDuration, RotateMode.LocalAxisAdd)
                .SetEase(Ease.OutQuad);  // 你可以根据需要修改缓动效果
        }

        Vector3[] pathPoints = new Vector3[3];
        pathPoints[0] = this.transform.position;  
        pathPoints[1] = middleLeaf.transform.position;  
        pathPoints[2] = endLeaf.transform.position;

        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        thePlayer.transform.DOPath(pathPoints, 1f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
         {
             thePlayer.GetComponent<PlayerMovement>().enabled = true;
         });

        this.GetComponent<Collider2D>().enabled = false;
    }
}
